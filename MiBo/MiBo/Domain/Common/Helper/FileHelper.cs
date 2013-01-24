using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace MiBo.Domain.Common.Helper
{
    public static class FileHelper
    {

        /// <summary>
        /// Read file into a string
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>Content of file</returns>
        public static string ToString(string path)
        {
            // Local variable declaration
            var sb = new StringBuilder();
            // Read file
            using (StreamReader reader = new StreamReader(path))
            {
                sb.Clear();
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            //Return value
            return sb.ToString();
        }

        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="stream">stream</param>
        /// <param name="path">Path</param>
        public static void SaveFile(Stream stream, string path)
        {
            // Local variable declaration
            var file = new FileInfo(path);
            var directory = file.Directory;
            // Check exist path
            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);

            // Create file
            var fileStream = File.Create(path);
            // Write file
            using (fileStream)
            {
                stream.CopyTo(fileStream);
            }
        }

        /// <summary>
        /// Save image
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="path">Path</param>
        /// <param name="format">ImageFormat</param>
        public static void SaveImage(Image img, string path, ImageFormat format)
        {
            // Local variable declaration
            var file = new FileInfo(path);
            var directory = file.Directory;
            // Local variable declaration
            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);
            // Save
            img.Save(path, format);
        }
    }
}