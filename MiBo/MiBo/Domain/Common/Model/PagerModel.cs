using System.Text;
using System.Web;

namespace MiBo.Domain.Common.Model
{
    public class PagerModel
    {
        public string ForControl { get; set; }
        public string Name { get; set; }
        public string Url { 
            get {
                var request = HttpContext.Current.Request;
                var keys = request.QueryString.AllKeys;
                var url = new StringBuilder();
                url.Append(request.Path);
                url.Append("?");
                foreach (var key in keys)
                {
                    if (key == "limit" || key == "offset")
                        continue;

                    url.Append(key);
                    url.Append("=");
                    url.Append(request[key]);
                    url.Append("&");
                }
                url.Append("limit");
                url.Append("=");
                url.Append(Limit);
                url.Append("&");
                url.Append("offset");
                url.Append("=");
                url.Append(Offset);

                return url.ToString();
            } 
        }

        public decimal Page { get; set; }
        public decimal Limit { get; set; }
        public decimal Offset { get { return decimal.Multiply(Page - 1, Limit);} }
    }
}