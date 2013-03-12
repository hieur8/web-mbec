using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;

namespace MiBo.pages.handler
{
    /// <summary>
    /// Summary description for FileTransferHandler
    /// </summary>
    public class UploadImageHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }
        private HandlerModel input = new HandlerModel();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Pragma", "no-cache");
            context.Response.AddHeader("Cache-Control", "private, no-cache");
            ConvertInput(context);
            ExecuteHandler(context);
        }

        private void ConvertInput(HttpContext context)
        {
            // Local variable declaration
            var request = new HandlerModel();

            // Set request
            request.Name = context.Request["f"];
            request.Path = context.Request["p"];

            // Convert data input
            DataHelper.ConvertInput(request, input);
        }

        // Handle request based on method
        private void ExecuteHandler(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "HEAD":
                case "GET":
                    if (!DataCheckHelper.IsNull(input.Name))
                        DeliverFile(context);
                    else ListCurrentFiles(context);
                    break;
                case "POST":
                case "PUT":
                    UploadFile(context);
                    break;
                case "DELETE":
                    DeleteFile();
                    break;
                case "OPTIONS":
                    ReturnOptions(context);
                    break;
                default:
                    context.Response.ClearHeaders();
                    context.Response.StatusCode = 405;
                    break;
            }
        }

        private void DeliverFile(HttpContext context)
        {
            if (FileHelper.ExistImages(input.PathLarger, Logics.EXT_JPEG))
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + input.Name + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(input.PathLarger);
            }
            else context.Response.StatusCode = 404;
        }

        private void ListCurrentFiles(HttpContext context)
        {
            // Local variable declaration
            var files = FileHelper.GetSmallImages(input.Path, Logics.EXT_JPEG);
            var listFiles = new List<FileModel>();

            // Check valid
            if (files == null)
            {
                files = new List<FileInfo>();
            }
            
            // Get data
            foreach (var obj in files)
            {
                listFiles.Add(new FileModel(obj, input.Path));
            }
            // Convert json
            var jsonObj = JsonHelper.Serialize(listFiles.ToArray());
            context.Response.AddHeader("Content-Disposition", "inline; filename=\"files.json\"");
            context.Response.Write(jsonObj);
            context.Response.ContentType = "application/json";
        }

        private void UploadFile(HttpContext context)
        {
            var fileModel = new List<FileModel>();
            var headers = context.Request.Headers;

            UploadWholeFile(context, fileModel);
            WriteJsonIframeSafe(context, fileModel);
        }

        private void DeleteFile()
        {
            FileHelper.DeleteImage(input.PathSmall + input.Name);
            FileHelper.DeleteImage(input.PathLarger + input.Name);
        }

        private void ReturnOptions(HttpContext context)
        {
            context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
            context.Response.StatusCode = 200;
        }

        private void UploadWholeFile(HttpContext context, List<FileModel> fs)
        {
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                var fileName = DataHelper.GetUniqueKey() + ".jpg";
                var file = context.Request.Files[i];
                UploadHelper.UploadImage(file.InputStream, input.PathSmall + fileName);
                UploadHelper.UploadImage(file.InputStream, input.PathLarger + fileName);
                fs.Add(new FileModel(fileName, input.Path, file.ContentLength));
            }
        }

        private void WriteJsonIframeSafe(HttpContext context, List<FileModel> fs)
        {
            context.Response.AddHeader("Vary", "Accept");
            try
            {
                if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    context.Response.ContentType = "application/json";
                else context.Response.ContentType = "text/plain";
            }
            catch
            {
                context.Response.ContentType = "text/plain";
            }
            var jsonObj = JsonHelper.Serialize(fs.ToArray());
            context.Response.Write(jsonObj);
        }
    }

    public class HandlerModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string PathSmall { get { return Path + Logics.URL_IMAGE_SMALL; } }
        public string PathLarger { get { return Path + Logics.URL_IMAGE_LARGER; } }
    }
    public class FileModel
    {
        public const string HandlerPath = "/";

		public string group { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public int size { get; set; }
		public string progress { get; set; }
		public string url { get; set; }
		public string thumbnail_url { get; set; }
		public string delete_url { get; set; }
		public string delete_type { get; set; }
		public string error { get; set; }

		public FileModel () { }

		public FileModel (FileInfo fileInfo, string path) { SetValues(fileInfo.Name, path, (int)fileInfo.Length); }

        public FileModel(string fileName, string path, int fileLength) { SetValues(fileName, path, fileLength); }

		private void SetValues(string fileName, string path, int fileLength) {
			name = fileName;
			type = "image/png";
			size = fileLength;
			progress = "1.0";
            url = "/pages/handler/UploadImageHandler.ashx?p=" + path + "&f=" + fileName;
            thumbnail_url = path + Logics.URL_IMAGE_SMALL + fileName;
            delete_url = "/pages/handler/UploadImageHandler.ashx?p=" + path + "&f=" + fileName;
			delete_type = "DELETE";
		}
    }
}