using System.Net.Http;
using System.Text;
using Skybrud.WebApi.Constants;

namespace Skybrud.WebApi {

    public class HttpTextResponseMessage : HttpResponseMessage {

        public HttpTextResponseMessage(string content) {
            Content = new StringContent(content ?? string.Empty, Encoding.UTF8, MediaTypes.Text.Plain);
        }

        public HttpTextResponseMessage(string content, string contentType) {
            Content = new StringContent(content ?? string.Empty, Encoding.UTF8, contentType ?? MediaTypes.Text.Plain);
        }

    }

}