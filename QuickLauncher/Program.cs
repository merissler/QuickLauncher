using QuickLauncher;
using QuickLauncher.Objects;

App[] allApps = FileHelper.GetAllApps();
string query = string.Empty;
App[] matches = allApps;

while (matches.Length != 1)
{
    Console.Clear();

    foreach (App a in matches)
    {
        Console.WriteLine(a.Name);
    }

    Console.WriteLine();
    Console.WriteLine();

    Console.Write(query);
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
    else if (key == ConsoleKey.Enter)
    {
        break;
    }
    else if (key == ConsoleKey.Escape)
    {
        Environment.Exit(0);
    }
    else
    {
        if (Char.IsLetterOrDigit(keyChar) || Char.IsPunctuation(keyChar) || keyChar == ' ')
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
}

FileHelper.RunShortcut(matches[0].Path);
