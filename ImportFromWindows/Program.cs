// Source directory to search for .lnk files
string appsRoot = Path.Combine();
string appsUser = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\";
// Destination directory where .lnk files will be copied
string dest = @"C:\DestinationDirectory";

try
{
    // Ensure the destination directory exists
    Directory.CreateDirectory(dest);

    // Get all .lnk files in the source directory and its subdirectories
    string[] files = Directory.GetFiles(appsRoot, "*.lnk", SearchOption.AllDirectories);

    foreach (string file in files)
    {
        // Get the file name
        string fileName = Path.GetFileName(file);

        // Combine destination directory path with file name
        string destinationFile = Path.Combine(dest, fileName);

        // Copy the file to the destination directory
        File.Copy(file, destinationFile, true);

        Console.WriteLine($"Copied {file} to {destinationFile}");
    }

    Console.WriteLine("All .lnk files have been copied.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
