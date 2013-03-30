namespace MiBo.Domain.Common.Model
{
    public class ImageSizeModel
    {
        public string SizeName { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public ImageSizeModel(string sizeName, decimal Width, decimal Height)
        {
            this.SizeName = sizeName;
            this.Width = Width;
            this.Height = Height;
        }
    }
}