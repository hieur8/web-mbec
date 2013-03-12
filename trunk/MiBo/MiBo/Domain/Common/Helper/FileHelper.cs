using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using System.Web;
using System;

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
            var strPath = HttpContext.Current.Server.MapPath(path);
            var sb = new StringBuilder();
            // Read file
            using (StreamReader reader = new StreamReader(strPath))
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
            var strPath = HttpContext.Current.Server.MapPath(path);
            var file = new FileInfo(strPath);
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
        /// Delete file
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>True/False</returns>
        public static bool DeleteFile(string path)
        {
            var strPath = HttpContext.Current.Server.MapPath(path);
            if (File.Exists(strPath))
            {
                try { File.Delete(strPath); }
                catch (Exception) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Move files
        /// </summary>
        /// <param name="sourcePath">SourcePath</param>
        /// <param name="targetPath">TargetPath</param>
        /// <param name="ext">Extension</param>
        public static void MoveFiles(string sourcePath, string targetPath, string ext)
        {
            // Local variable declaration
            var strSourcePath = HttpContext.Current.Server.MapPath(sourcePath);
            var strTargetPath = HttpContext.Current.Server.MapPath(targetPath);
            var sourceFolder = new DirectoryInfo(strSourcePath);
            var targetFolder = new DirectoryInfo(strTargetPath);
            // Check exist
            if (!sourceFolder.Exists) return;
            if (!targetFolder.Exists) Directory.CreateDirectory(targetFolder.FullName);
            // Move files
            foreach (var obj in sourceFolder.GetFiles(ext, SearchOption.TopDirectoryOnly))
            {
                // Delete file
                if (File.Exists(targetFolder.FullName + obj.Name))
                    File.Delete(targetFolder.FullName + obj.Name);
                // Move file
                obj.MoveTo(targetFolder.FullName + obj.Name);
            }
        }

        /// <summary>
        /// Copy files
        /// </summary>
        /// <param name="sourcePath">SourcePath</param>
        /// <param name="targetPath">TargetPath</param>
        /// <param name="ext">Extension</param>
        public static void CopyFiles(string sourcePath, string targetPath, string ext)
        {
            // Local variable declaration
            var strSourcePath = HttpContext.Current.Server.MapPath(sourcePath);
            var strTargetPath = HttpContext.Current.Server.MapPath(targetPath);
            var sourceFolder = new DirectoryInfo(strSourcePath);
            var targetFolder = new DirectoryInfo(strTargetPath);
            // Check exist
            if (!sourceFolder.Exists) return;
            if (!targetFolder.Exists) Directory.CreateDirectory(targetFolder.FullName);
            // Move files
            foreach (var obj in sourceFolder.GetFiles(ext, SearchOption.TopDirectoryOnly))
            {
                obj.CopyTo(targetFolder.FullName + obj.Name, true);
            }
        }

        /// <summary>
        /// Get files
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="ext">Extension</param>
        /// <returns>Files</returns>
        public static IList<FileInfo> GetFiles(string path, string ext)
        {
            // Local variable declaration
            var strPath = HttpContext.Current.Server.MapPath(path);
            var folder = new DirectoryInfo(strPath);
            // Check exist
            if (!folder.Exists) return null;
            // Get files
            var files = new List<FileInfo>();
            foreach (var obj in folder.GetFiles(ext, SearchOption.TopDirectoryOnly))
            {
                files.Add(obj);
            }
            // return value
            return files;
        }

        /// <summary>
        /// Exist files
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="ext">Extension</param>
        /// <returns>True/False</returns>
        public static bool ExistFiles(string path, string ext)
        {
            // Get files
            var files = GetFiles(path, ext);
            // return value
            return (files != null && files.Count > 0);
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
            var strPath = HttpContext.Current.Server.MapPath(path);
            var file = new FileInfo(strPath);
            var directory = file.Directory;
            // Create directory
            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);
            // Save
            img.Save(strPath, format);
        }

        /// <summary>
        /// Delete image
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>True/False</returns>
        public static bool DeleteImage(string path)
        {
            var strPath = HttpContext.Current.Server.MapPath(path);
            if (File.Exists(strPath) && Path.GetFileName(strPath).ToLower() != "default.jpg")
            {
                try { File.Delete(strPath); }
                catch (Exception) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Move files
        /// </summary>
        /// <param name="sourcePath">SourcePath</param>
        /// <param name="targetPath">TargetPath</param>
        /// <param name="ext">Extension</param>
        public static void MoveImages(string sourcePath, string targetPath, string ext)
        {
            MoveFiles(sourcePath + Logics.URL_IMAGE_SMALL,
                targetPath + Logics.URL_IMAGE_SMALL, ext);
            MoveFiles(sourcePath + Logics.URL_IMAGE_LARGER,
                targetPath + Logics.URL_IMAGE_LARGER, ext);
        }

        /// <summary>
        /// Copy files
        /// </summary>
        /// <param name="sourcePath">SourcePath</param>
        /// <param name="targetPath">TargetPath</param>
        /// <param name="ext">Extension</param>
        public static void CopyImages(string sourcePath, string targetPath, string ext)
        {
            CopyFiles(sourcePath + Logics.URL_IMAGE_SMALL,
                targetPath + Logics.URL_IMAGE_SMALL, ext);
            CopyFiles(sourcePath + Logics.URL_IMAGE_LARGER,
                targetPath + Logics.URL_IMAGE_LARGER, ext);
        }

        /// <summary>
        /// Get files
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="ext">Extension</param>
        /// <returns>Files</returns>
        public static IList<FileInfo> GetSmallImages(string path, string ext)
        {
            return GetFiles(path + Logics.URL_IMAGE_SMALL, ext);
        }

        /// <summary>
        /// Get files
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="ext">Extension</param>
        /// <returns>Files</returns>
        public static IList<FileInfo> GetLargerImages(string path, string ext)
        {
            return GetFiles(path + Logics.URL_IMAGE_LARGER, ext);
        }

        /// <summary>
        /// Exist files
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="ext">Extension</param>
        /// <returns>True/False</returns>
        public static bool ExistImages(string path, string ext)
        {
            return ExistFiles(path + Logics.URL_IMAGE_SMALL, ext);
        }

        /// <summary>
        /// Get file
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="ext">Extension</param>
        /// <returns>File</returns>
        public static FileInfo GetSmallImage(string path, string ext)
        {
            var files = GetFiles(path + Logics.URL_IMAGE_SMALL, ext);
            return files[0];
        }
    }
}