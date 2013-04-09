using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MiBo.Domain.Common.Enum;

namespace MiBo.Domain.Common.Helper
{
    public static class ImageHelper
    {
        /// <summary>
        /// Resize image
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="newWidth">Width</param>
        /// <param name="newHeight">Height</param>
        /// <returns>Image</returns>
        public static Image Resize(Image img, decimal newWidth, decimal newHeight)
        {
            // Local variable declaration
            var width = 0;
            var height = 0;
            Bitmap bmp = null;
            Graphics grp = null;

            // Variable initialize
            width = decimal.ToInt32(newWidth);
            height = decimal.ToInt32(newHeight);
            bmp = new Bitmap(width, height);
            grp = Graphics.FromImage(bmp);

            // Resize
            grp.CompositingQuality = CompositingQuality.HighQuality;
            grp.SmoothingMode = SmoothingMode.HighQuality;
            grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grp.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grp.Clear(Color.White);
            grp.DrawImage(img, 0, 0, width, height);
            grp.Dispose();

            // Return value
            return bmp;
        }

        /// <summary>
        /// Resize image with ratio
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="ratioSize">Ratio size</param>
        /// <param name="ratioType">Ratio type</param>
        /// <returns>Image</returns>
        public static Image Resize(Image img, decimal ratioSize, RatioType ratioType)
        {
            // Local variable declaration
            Image imgResize = null;
            var width = decimal.Zero;
            var height = decimal.Zero;
            // Check ratio type
            if (ratioType == RatioType.Width && img.Width > ratioSize)
            {
                width = ratioSize;
                height = Math.Round(width / decimal.Divide(img.Width, img.Height));
                imgResize = Resize(img, width, height);
            }
            else if (ratioType == RatioType.Height && img.Height > ratioSize)
            {
                height = ratioSize;
                width = Math.Round(height * decimal.Divide(img.Width, img.Height));
                imgResize = Resize(img, width, height);
            }
            else { imgResize = Resize(img, img.Width, img.Height); }
            // Return value
            return imgResize;
        }
    }
}