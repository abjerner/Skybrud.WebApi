using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Skybrud.WebApi {

    public class HttpImageResponseMessage : HttpResponseMessage {

        public HttpImageResponseMessage(string path) {
            Content = new ByteArrayContent(File.ReadAllBytes(path));
            Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
        }

        public HttpImageResponseMessage(string path, string mediaType) {
            Content = new ByteArrayContent(File.ReadAllBytes(path));
            Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType ?? "image/png");
        }

    }

}