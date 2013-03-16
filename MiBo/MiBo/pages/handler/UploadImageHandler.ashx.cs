using System.Collections.Generic;
using System.IO;
using System.Web;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;

namespace MiBo.pages.handler
{
    /// <summary>
    /// Summary description for FileTransferHandler
    /// </summary>
    public class UploadImageHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }
        private UploadModel input = new UploadModel();
        private const string handler = "UploadImageHandler.ashx";
        private const string GROUP_ITEM = "item";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Pragma", "no-cache");
            context.Response.AddHeader("Cache-Control", "private, no-cache");
            ConvertInput(context);
            ExecuteHandler(context);
            context.Response.Flush();
        }

        private void ConvertInput(HttpContext context)
        {
            // Local variable declaration
            var request = new UploadModel();

            // Set request
            request.FileName = context.Request["f"];
            request.Url = context.Request["p"];
            request.Group = context.Request["g"];
            request.ContentType = "image/jpeg";

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
                    if (!DataCheckHelper.IsNull(input.FileName))
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
            if (FileHelper.ExistImages(input.UrlImageLarger, Logics.EXT_JPEG))
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + input.FileName + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(input.UrlImageLarger);
            }
            else context.Response.StatusCode = 404;
        }

        private void ListCurrentFiles(HttpContext context)
        {
            // Local variable declaration
            var files = FileHelper.GetSmallImages(input.Url, Logics.EXT_JPEG);
            var listFiles = new List<FileModel>();

            // Check valid
            if (files == null)
            {
                files = new List<FileInfo>();
            }

            // Get data
            foreach (var obj in files)
            {
                var file = new FileModel(handler, (int)obj.Length, obj.Name, input);
                listFiles.Add(file);
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
            if (input.Group == GROUP_ITEM)
            {
                UploadHelper.DeleteFile(input.FullUrlImageSmall);
                UploadHelper.DeleteFile(input.FullUrlImageNormal);
                UploadHelper.DeleteFile(input.FullUrlImageLarger);
            }
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
                if (input.Group == GROUP_ITEM)
                {
                    UploadHelper.UploadImage(file.InputStream, 60, 60, input.UrlImageSmall + fileName);
                    UploadHelper.UploadImage(file.InputStream, 170, 170, input.UrlImageNormal + fileName);
                    UploadHelper.UploadImage(file.InputStream, 400, 400, input.UrlImageLarger + fileName);

                    var f = new FileModel(handler, file.ContentLength, fileName, input);
                    fs.Add(f);
                }
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
}