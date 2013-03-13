namespace MiBo.Domain.Common.Model
{
    public class FileModel
    {
        public const string HandlerPath = "/pages/handler/";

        public int Size { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Progress { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string DeleteType { get; set; }

        public string error { get; set; }

        public FileModel(string handler, int size, string fileName, UploadModel model) {
            Name = fileName;
            Type = model.ContentType;
            Size = size;
            Progress = "1.0";
            Url = HandlerPath + handler + "?g=" + model.Group + "&p=" + model.Url + "&f=" + fileName;
            ThumbnailUrl = model.UrlImageSmall + fileName;
            DeleteUrl = HandlerPath + handler + "?g=" + model.Group + "&p=" + model.Url + "&f=" + fileName;
            DeleteType = "DELETE";
        }
    }
}