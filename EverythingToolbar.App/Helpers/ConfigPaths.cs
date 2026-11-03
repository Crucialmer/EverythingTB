using System;
using System.IO;

namespace EverythingToolbar.App.Helpers
{
    public static class ConfigPaths
    {
        public static string GetConfigDirectory()
        {
            // Pure Green / Portable Mode:
            // Store configuration, rules.xml, and settings strictly in application directory's Config subfolder.
            string portableDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
            if (!Directory.Exists(portableDir))
            {
                Directory.CreateDirectory(portableDir);
            }
            return portableDir;
        }
    }
}
