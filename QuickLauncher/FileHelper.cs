using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using QuickLauncher.Objects;

namespace QuickLauncher
{
    internal static class FileHelper
    {
        public static string GetAppDataPath()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appDataPath, "QuickLauncher");
        }

        public static string GetAppsPath()
        {
            return GetAppsPath("0");
        }
        public static string GetAppsPath(string subDir)
        {
            string appDataPath = GetAppDataPath();
            return Path.Combine(appDataPath, "Apps", subDir);
        }

        public static void CreateAppDataIfNone()
        {
            string appDataPath = GetAppDataPath();
            string appsPath = GetAppsPath();

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            if (!Directory.Exists(appsPath))
            {
                Directory.CreateDirectory(appsPath);
            }
        }

        public static App[] GetAllApps()
        {
            return GetAllApps("0");
        }
        public static App[] GetAllApps(string subDir)
        {
            return GetAllApps(subDir, String.Empty);
        }
        public static App[] GetAllApps(string subDir, string startsWith)
        {
            CreateAppDataIfNone();

            string appsDir = GetAppsPath(subDir);

            if (Directory.Exists(appsDir))
            {
                string[] files = Directory.GetFiles(appsDir, "*.lnk");

                if (files.Length > 0)
                {
                    HashSet<App> apps = new HashSet<App>();

                    foreach (string f in files)
                    {
                        App a = new App
                        {
                            Name = Path.GetFileNameWithoutExtension(f),
                            Path = f
                        };

                        if (a.Name.StartsWith(startsWith))
                        {
                            apps.Add(a);
                        }
                    }

                    return apps.ToArray();
                }
                else
                {
                    return [];
                }
            }
            else
            {
                return [];
            }
        }

        public static void RunShortcut(string shortcutPath)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = shortcutPath,
                    UseShellExecute = true,
                };

                Process.Start(processStartInfo);

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
