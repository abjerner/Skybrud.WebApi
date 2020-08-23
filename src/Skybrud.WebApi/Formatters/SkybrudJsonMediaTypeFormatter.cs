using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Skybrud.WebApi.Formatters {

    public class SkybrudJsonMediaTypeFormatter : JsonMediaTypeFormatter {

        private string _callbackQueryParameter;

        public bool AllowCallback { get; set; }
            
        public string CallbackQueryParameter {
            get => _callbackQueryParameter ?? "callback";
            set => _callbackQueryParameter = value;
        }

        public SkybrudJsonMediaTypeFormatter() {
            SupportedMediaTypes.Add(DefaultMediaType);
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));
            MediaTypeMappings.Add(new UriPathExtensionMapping("jsonp", DefaultMediaType));
        }

        public SkybrudJsonMediaTypeFormatter(bool allowCallback) {
            SupportedMediaTypes.Add(DefaultMediaType);
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));
            MediaTypeMappings.Add(new UriPathExtensionMapping("jsonp", DefaultMediaType));
            AllowCallback = allowCallback;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContent content, TransportContext context) {
            if (IsJsonpRequest(out string callback)) {
                return Task.Factory.StartNew(() => {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(callback + "(");
                    writer.Flush();
                    base.WriteToStreamAsync(type, value, stream, content, context).Wait();
                    writer.Write(")");
                    writer.Flush();
                });
            }
            return base.WriteToStreamAsync(type, value, stream, content, context);
        }

        private bool IsJsonpRequest(out string callback) {
            callback = null;
            if (AllowCallback == false || HttpContext.Current.Request.HttpMethod != "GET") return false;
            callback = HttpContext.Current.Request.QueryString[CallbackQueryParameter];
            return string.IsNullOrEmpty(callback) == false;
        }

    }

}