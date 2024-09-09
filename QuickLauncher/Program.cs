using QuickLauncher.Objects;
using System.Diagnostics;

namespace QuickLauncher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string appsSubDir = "0";

            if (args.Length > 0)
            {
                appsSubDir = args[0];
            }

            App[] allApps = FileHelper.GetAllApps(appsSubDir);
            string query = string.Empty;
            App[] matches = allApps;
            int selectedIndex = 0;

            if (allApps.Length > 0)
            {
                while (matches.Length != 1)
                {
                    Console.Clear();

                    for (int i = 0; i < matches.Length; i++)
                    {
                        App a = matches[i];

                        if (i == selectedIndex)
                        {
                            Console.Write("> ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }

                        Console.WriteLine(a.Name);
                    }

                    Console.Write("\n  " + query);
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey key = keyInfo.Key;
                    char keyChar = keyInfo.KeyChar;

                    if (key == ConsoleKey.Backspace)
                    {
                        if (query.Length > 0)
                        {
                            query = query.Remove(query.Length - 1);
                        }
                    }
                    else if (key == ConsoleKey.Tab)
                    {
                        if (keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift))
                        {
                            selectedIndex -= 1;
                        }
                        else
                        {
                            selectedIndex += 1;
                        }
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else if (key == ConsoleKey.F12)
                    {
                        string appDataPath = FileHelper.GetAppsPath(appsSubDir);
                        Process.Start("explorer.exe", appDataPath);
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (!Char.IsControl(keyChar))
                        {
                            if (!Path.GetInvalidFileNameChars().Contains(keyChar))
                            {
                                query += keyChar;
                            }
                        }
                    }

                    if (query != string.Empty)
                    {
                        matches = allApps.Where(a => StringHelper.AnyWordStartsWith(a.Name, query.Trim())).ToArray();
                    }
                    else
                    {
                        matches = allApps;
                    }

                    selectedIndex = Math.Clamp(selectedIndex, 0, Math.Max(0, matches.Length - 1));
                }

                FileHelper.RunShortcut(matches[selectedIndex].Path);
            }
            else
            {
                Console.WriteLine("QuickLauncher currently has no apps.\n");
                Console.WriteLine("Would you like to import apps from the Windows start menu?");
                Console.Write("(Y/N)");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar == 'n' || key.KeyChar == 'N' || key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else if (key.KeyChar == 'y' || key.KeyChar == 'Y')
                    {
                        string defaultAppsPath = FileHelper.GetAppsPath();
                        ImportFromWindows.Importer.Import(defaultAppsPath);
                        return;
                    }
                }
            }
        }
    }
}
