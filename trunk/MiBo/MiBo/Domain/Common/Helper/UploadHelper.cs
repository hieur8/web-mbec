using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MiBo.Domain.Common.Enum;

namespace MiBo.Domain.Common.Helper
{
    public static class UploadHelper
    {
        public const string URL_UPLOAD_DEFAULT = "\\pages\\media\\temp\\";

        /// <summary>
        /// Get upload url
        /// </summary>
        /// <returns>UploadUrl</returns>
        public static string GetUploadUrl()
        {
            return URL_UPLOAD_DEFAULT + DataHelper.GetUniqueKey() + "\\";
        }

        /// <summary>
        /// Upload image
        /// </summary>
        /// <param name="data">Stream</param>
        /// <param name="path">Path</param>
        public static void UploadImage(Stream data, string path)
        {
            // Local variable declaration
            Image imgInput = null;
            // Read file
            imgInput = Image.FromStream(data);
            // Save file
            FileHelper.SaveImage(imgInput, path, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Upload image with width and height
        /// </summary>
        /// <param name="data">Stream</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="path">Path</param>
        public static void UploadImage(Stream data, decimal width, decimal height, string path)
        {
            // Upload image
            UploadImage(data, width, height, path, false, false);
        }

        /// <summary>
        /// Upload image with width ratio, height ratio
        /// </summary>
        /// <param name="data">Stream</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="path">Path</param>
        /// <param name="ratioWidth">Ratio width</param>
        /// <param name="ratioHeight">Ratio height</param>
        public static void UploadImage(Stream data, decimal width, decimal height, string path, bool ratioWidth, bool ratioHeight)
        {
            // Local variable declaration
            Image imgInput = null;
            Image imgResize = null;
            // Read file
            imgInput = Image.FromStream(data);
            // Resize image
            if (ratioHeight && imgInput.Width < imgInput.Height)
                imgResize = ImageHelper.Resize(imgInput, height, RatioType.Height);
            else if (ratioWidth && imgInput.Width > imgInput.Height)
                imgResize = ImageHelper.Resize(imgInput, width, RatioType.Width);
            else imgResize = ImageHelper.Resize(imgInput, width, height);
            // Save file
            FileHelper.SaveImage(imgResize, path, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Upload image with ratio
        /// </summary>
        /// <param name="data">Stream</param>
        /// <param name="ratioSize">Ratio size</param>
        /// <param name="ratioType">Ratio type</param>
        /// <param name="path">Path</param>
        public static void UploadImage(Stream data, decimal ratioSize, RatioType ratioType, string path)
        {
            // Local variable declaration
            Image imgInput = null;
            Image imgResize = null;
            // Read file
            imgInput = Image.FromStream(data);
            // Resize image
            imgResize = ImageHelper.Resize(imgInput, ratioSize, ratioType);
            // Save file
            FileHelper.SaveImage(imgResize, path, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Delete image
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>True/False</returns>
        public static bool DeleteImage(string path)
        {
            return FileHelper.DeleteImage(path);
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="data">Stream</param>
        /// <param name="path">Path</param>
        public static void UploadFile(Stream data, string path)
        {
            FileHelper.SaveFile(data, path);
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>True/False</returns>
        public static bool DeleteFile(string path)
        {
            return FileHelper.DeleteFile(path);
        }
    }
}