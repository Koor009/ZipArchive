using System;
using System.IO;
using System.IO.Compression;

namespace Zip_Archive
{
    sealed class Program
    {

        private static void Main()
        {
            Console.WriteLine("Provide path where the zip file:");
            string extractPath = Console.ReadLine();

            archivePath(extractPath);
        }

        /// <summary>
        /// Prosess a Zip archive. Method A.
        /// </summary>
        /// <param name="pathToArchive">Path to archive Zip.</param>
        public static void archivePath(string pathToArchive)
        {
            if (string.IsNullOrEmpty(pathToArchive))
            {
                throw new ArgumentNullException(nameof(pathToArchive));
            }

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"temp_{Guid.NewGuid().ToString()}");

            Directory.CreateDirectory(folderPath);

            using (ZipArchive zipArchive = ZipFile.OpenRead(pathToArchive))
            {
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {

                    if (entry.FullName.EndsWith(".csv"))
                    {

                        string path = Path.Combine(folderPath, entry.FullName);

                        entry.ExtractToFile(path);

                        ProcessFile(path);
                    }
                }
                Directory.Delete(folderPath, true);
            }
        }

        /// <summary>
        /// Prosess a file. Method B.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        public static void ProcessFile(string filePath)
        {
        }
    }
}