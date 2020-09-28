using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Skybrud.WebApi.Constants;

namespace Skybrud.WebApi {

    public class HttpImageResponseMessage : HttpResponseMessage {

        public HttpImageResponseMessage(string path) {
            Content = new ByteArrayContent(File.ReadAllBytes(path));
            Content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypes.Image.Png);
        }

        public HttpImageResponseMessage(string path, string mediaType) {
            Content = new ByteArrayContent(File.ReadAllBytes(path));
            Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType ?? MediaTypes.Image.Png);
        }

    }

}