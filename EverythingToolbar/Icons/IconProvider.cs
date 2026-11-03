using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.UI.HiDpi;
using Windows.Win32.UI.Shell;

namespace EverythingToolbar.Icons
{
    public static class DpiHelper
    {
        public const double DefaultDpi = 96.0;

        /// <summary>
        /// Gets the effective DPI for the active search window, or the monitor where the cursor is located,
        /// supporting ultra-high DPI scaling all the way up to 8K resolution (e.g. 300% - 500% DPI).
        /// </summary>
        public static double GetCurrentDpi()
        {
            if (Application.Current != null)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.IsVisible)
                    {
                        var handle = new WindowInteropHelper(window).Handle;
                        if (handle != IntPtr.Zero)
                        {
                            uint winDpi = PInvoke.GetDpiForWindow((HWND)handle);
                            if (winDpi >= 96)
                                return winDpi;
                        }
                    }
                }
            }

            try
            {
                var cursor = System.Windows.Forms.Cursor.Position;
                var monitor = PInvoke.MonitorFromPoint(
                    new System.Drawing.Point(cursor.X, cursor.Y),
                    MONITOR_FROM_FLAGS.MONITOR_DEFAULTTONEAREST
                );
                if (PInvoke.GetDpiForMonitor(monitor, MONITOR_DPI_TYPE.MDT_EFFECTIVE_DPI, out var dpiX, out _).Succeeded && dpiX >= 96)
                {
                    return dpiX;
                }
            }
            catch
            {
                // Fallback
            }

            double systemDpi = PInvoke.GetDpiForSystem();
            return systemDpi >= 96 ? systemDpi : DefaultDpi;
        }

        public static double GetEffectiveDpiScale() => GetCurrentDpi() / DefaultDpi;
    }

    internal static class ImageScalingHelper
    {
        public static int GetScaledSize(int logicalSize)
        {
            double dpi = DpiHelper.GetCurrentDpi();


            return (int)Math.Ceiling(logicalSize * dpi / 96.0);
        }

        public static BitmapSource SetLogicalSize(BitmapSource source, int logicalSize, bool downOnly = false)
        {
            double targetLogicalSize = logicalSize;
            if (downOnly)
            {
                double currentDpi = DpiHelper.GetCurrentDpi();



                double nativeLogicalSize = source.PixelWidth * 96.0 / currentDpi;
                targetLogicalSize = Math.Min(logicalSize, nativeLogicalSize);
            }

            if (targetLogicalSize <= 0)
                return source;

            double targetDpi = source.PixelWidth * 96.0 / targetLogicalSize;
            if (Math.Abs(source.DpiX - targetDpi) < 0.1)
                return source;

            int width = source.PixelWidth;
            int height = source.PixelHeight;
            var format = source.Format;
            int stride = (width * format.BitsPerPixel + 7) / 8;
            byte[] pixels = new byte[stride * height];
            source.CopyPixels(pixels, stride, 0);
            var result = BitmapSource.Create(
                width,
                height,
                targetDpi,
                targetDpi,
                format,
                source.Palette,
                pixels,
                stride
            );
            result.Freeze();
            return result;
        }
    }

    public static class ThumbnailProvider
    {
        public static ImageSource? GetImage(string filePath, int imageSize, bool allowUpscaling = true)
        {
            IShellItemImageFactory? imageFactory = null;
            try
            {
                int scaledSize = ImageScalingHelper.GetScaledSize(imageSize);

                PInvoke.SHCreateItemFromParsingName(filePath, null, out IShellItemImageFactory factory);
                imageFactory = factory;

                factory.GetImage(
                    new System.Drawing.Size(scaledSize, scaledSize),
                    SIIGBF.SIIGBF_RESIZETOFIT,
                    out var hBitmap
                );

                try
                {
                    var imageSource = Imaging.CreateBitmapSourceFromHBitmap(
                        hBitmap.DangerousGetHandle(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions()
                    );
                    imageSource.Freeze();
                    return ImageScalingHelper.SetLogicalSize(imageSource, imageSize, downOnly: !allowUpscaling);
                }
                finally
                {
                    hBitmap.Dispose();
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (imageFactory != null && Marshal.IsComObject(imageFactory))
                    Marshal.ReleaseComObject(imageFactory);
            }
        }
    }

    public static class IconProvider
    {
        private static readonly ConcurrentDictionary<string, ImageSource> IconByIndexAndScaleCache = new();
        private static readonly ConcurrentDictionary<string, int> ExtensionToIndexMap = new();

        private static readonly int FallbackDirectoryIconIndex;

        static IconProvider()
        {
            FallbackDirectoryIconIndex = GetIconIndex("asdf1234", IconIndexType.DirectoryName);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct ShFileInfo
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref ShFileInfo psfi,
            uint cbSizeFileInfo,
            uint uFlags
        );

        private const uint ShgfiSmallicon = 0x000000001;
        private const uint ShgfiSysiconindex = 0x000004000;
        private const uint ShgfiUsefileattributes = 0x000000010;
        private const uint FileAttributeNormal = 0x00000080;
        private const uint FileAttributeDirectory = 0x00000010;

        public static ImageSource? GetImage(string path, bool isFile, int iconSize)
        {
            int iconIndexByExt;
            if (isFile)
            {
                var extension = Path.GetExtension(path);
                if (!ExtensionToIndexMap.TryGetValue(extension, out iconIndexByExt))
                {
                    iconIndexByExt = GetIconIndex($"asdf1234.{extension}", IconIndexType.ByFileName);
                    ExtensionToIndexMap.TryAdd(extension, iconIndexByExt);
                }
            }
            else
            {
                iconIndexByExt = FallbackDirectoryIconIndex;
            }

            int scaledSize = ImageScalingHelper.GetScaledSize(iconSize);
            var iconByIndexAndScaleCacheKey = $"{iconIndexByExt}_{iconSize}@{scaledSize}";
            if (!IconByIndexAndScaleCache.TryGetValue(iconByIndexAndScaleCacheKey, out var iconByExtAndScale))
            {
                iconByExtAndScale = GetIconFromSystemImageList(iconIndexByExt, iconSize);
                if (iconByExtAndScale != null)
                {
                    IconByIndexAndScaleCache.TryAdd(iconByIndexAndScaleCacheKey, iconByExtAndScale);
                }
            }

            return iconByExtAndScale;
        }

        // Can block on network paths (SHGetFileInfo touches the file system) - do not call on the UI thread.
        public static ImageSource? GetExactImage(string path, int iconSize)
        {
            int exactIconIndex = GetIconIndex(path, IconIndexType.ByFilePath);
            int scaledSize = ImageScalingHelper.GetScaledSize(iconSize);
            var exactIconCacheKey = $"{exactIconIndex}_{iconSize}@{scaledSize}";
            if (IconByIndexAndScaleCache.TryGetValue(exactIconCacheKey, out var cachedExactIcon))
                return cachedExactIcon;

            ImageSource? exactIcon = GetIconFromSystemImageList(exactIconIndex, iconSize);
            if (exactIcon != null)
                IconByIndexAndScaleCache.TryAdd(exactIconCacheKey, exactIcon);

            return exactIcon;
        }

        private static int GetIconIndex(string path, IconIndexType indexType)
        {
            ShFileInfo shfi = new();
            uint flags = ShgfiSysiconindex | ShgfiSmallicon;
            uint fileAttributes = 0;
            if (indexType == IconIndexType.ByFileName)
            {
                fileAttributes = FileAttributeNormal;
                flags |= ShgfiUsefileattributes;
            }
            else if (indexType == IconIndexType.DirectoryName)
            {
                fileAttributes = FileAttributeDirectory;
                flags |= ShgfiUsefileattributes;
            }
            SHGetFileInfo(path, fileAttributes, ref shfi, (uint)Marshal.SizeOf(shfi), flags);
            return shfi.iIcon;
        }

        enum IconIndexType
        {
            ByFileName,
            ByFilePath,
            DirectoryName,
        }

        private const int IldTransparent = 0x00000001;
        private const int ShilLarge = 0;
        private const int ShilSmall = 1;
        private const int ShilExtralarge = 2;
        private const int ShilJumbo = 4;

        private static unsafe ImageSource? GetIconFromSystemImageList(int iconIndex, int iconSize)
        {
            int scaledSize = ImageScalingHelper.GetScaledSize(iconSize);

            Windows.Win32.UI.Controls.IImageList? imageList = null;
            try
            {
                int imageListType = GetImageListType(scaledSize);
                Guid iid = typeof(Windows.Win32.UI.Controls.IImageList).GUID;
                object ppv;
                if (PInvoke.SHGetImageList(imageListType, &iid, out ppv).Failed)
                {
                    if (imageListType == ShilJumbo && PInvoke.SHGetImageList(ShilExtralarge, &iid, out ppv).Succeeded)
                    {
                    }
                    else if (PInvoke.SHGetImageList(ShilLarge, &iid, out ppv).Failed)
                    {
                        return null;
                    }
                }

                imageList = (Windows.Win32.UI.Controls.IImageList)ppv;

                imageList.GetIcon(iconIndex, IldTransparent, out var hIcon);
                if (hIcon == null || hIcon.IsInvalid)
                    return null;


                try
                {
                    var imageSource = Imaging.CreateBitmapSourceFromHIcon(
                        hIcon.DangerousGetHandle(),
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions()
                    );
                    imageSource.Freeze();
                    return ImageScalingHelper.SetLogicalSize(imageSource, iconSize);
                }
                finally
                {
                    hIcon.Dispose();
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (imageList != null && Marshal.IsComObject(imageList))
                    Marshal.ReleaseComObject(imageList);
            }
        }

        private static int GetImageListType(int iconSize)
        {
            if (iconSize <= 16)
                return ShilSmall;
            if (iconSize <= 32)
                return ShilLarge;
            if (iconSize <= 48)
                return ShilExtralarge;
            return ShilJumbo;
        }
    }
}
