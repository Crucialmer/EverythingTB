using System;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Threading;
using EverythingToolbar.Platform.Helpers;

namespace EverythingToolbar.Controls
{
    public partial class DateWidget
    {
        private const byte VK_LWIN = 0x5B;
        private const byte VK_N = 0x4E;
        private const uint KEYEVENTF_KEYUP = 0x0002;

        private readonly DispatcherTimer _timer;

        public DateWidget()
        {
            InitializeComponent();
            UpdateDateTimeDisplay();

            _timer = new DispatcherTimer(DispatcherPriority.Background)
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            _timer.Tick += (_, _) => UpdateDateTimeDisplay();
            Loaded += (_, _) => _timer.Start();
            Unloaded += (_, _) => _timer.Stop();
        }

        private void UpdateDateTimeDisplay()
        {
            var now = DateTime.Now;
            var culture = CultureInfo.CurrentCulture;

            if (culture.TwoLetterISOLanguageName.Equals("zh", StringComparison.OrdinalIgnoreCase))
            {
                DateText.Text = now.ToString("M月d日 ddd", culture);
            }
            else
            {
                DateText.Text = now.ToString("MMM d, ddd", culture);
            }

            PillBorder.ToolTip = $"{now.ToString("D", culture)}  {now.ToString("t", culture)}\n点击呼出系统日历";
        }

        private void OnWidgetClicked(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Simulate Win + N on Windows 11 to toggle Notification Center / Calendar
                NativeMethods.SendKeybdEvent(VK_LWIN, 0, 0, IntPtr.Zero);
                NativeMethods.SendKeybdEvent(VK_N, 0, 0, IntPtr.Zero);
                NativeMethods.SendKeybdEvent(VK_N, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
                NativeMethods.SendKeybdEvent(VK_LWIN, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
            }
            catch
            {
                // Fallback: ignore
            }
        }
    }
}
