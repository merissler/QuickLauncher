namespace QuickLauncher.ImportFromWindows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Importer.Import(args[0]);
            }
        }
    }

    public static class Importer
    {
        /// <param name="args"></param>
        public static void Import(string destination)
        {
            const string startMenuSystem = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs";
            string startMenuUser = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\Start Menu\Programs");

            // Ensure the launcherApps directory exists
            Directory.CreateDirectory(destination);

            // Copy .lnk files from the system Start Menu
            CopyLnkFiles(startMenuSystem, destination);

            // Copy .lnk files from the user Start Menu
            CopyLnkFiles(startMenuUser, destination);
        }

        private static void CopyLnkFiles(string sourceDirectory, string destinationDirectory)
        {
            try
            {
                // Get all .lnk files in the source directory
                string[] lnkFiles = Directory.GetFiles(sourceDirectory, "*.lnk");

                foreach (string file in lnkFiles)
                {
                    // Get the file name without the path
                    string fileName = Path.GetFileName(file);
                    // Define the destination path
                    string destFile = Path.Combine(destinationDirectory, fileName);
                    // Copy the file to the destination directory
                    File.Copy(file, destFile, true); // Overwrite if the file already exists
                }

                string[] subDirs = Directory.GetDirectories(sourceDirectory);
                foreach (string subDir in subDirs)
                {
                    CopyLnkFiles(subDir, destinationDirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying files from {sourceDirectory}: {ex.Message}");
            }
        }
    }
}
