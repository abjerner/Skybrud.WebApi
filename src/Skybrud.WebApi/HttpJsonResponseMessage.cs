using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Skybrud.WebApi.Constants;

namespace Skybrud.WebApi {

    public class HttpJsonResponseMessage : HttpResponseMessage {

        public HttpJsonResponseMessage(object data) {
            Content = new StringContent(Serialize(data, Formatting.None), Encoding.UTF8, MediaTypes.Json);
        }

        public HttpJsonResponseMessage(object data, Formatting formatting) {
            Content = new StringContent(Serialize(data, formatting), Encoding.UTF8, MediaTypes.Json);
        }

        protected string Serialize(object data, Formatting formatting) {
            return JsonConvert.SerializeObject(data, formatting);
        }

    }

}