using System.Net.Http;
using System.Text;

namespace Skybrud.WebApi {

    public class HttpTextResponseMessage : HttpResponseMessage {

        public HttpTextResponseMessage(string content) {
            Content = new StringContent(content ?? string.Empty, Encoding.UTF8, "text/plain");
        }

        public HttpTextResponseMessage(string content, string contentType) {
            Content = new StringContent(content ?? string.Empty, Encoding.UTF8, contentType ?? "text/plain");
        }

    }

}