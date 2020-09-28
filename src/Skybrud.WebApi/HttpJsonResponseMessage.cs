using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using Newtonsoft.Json;
using Skybrud.WebApi.Constants;

namespace Skybrud.WebApi {

    public class HttpJsonResponseMessage : HttpResponseMessage {

        public HttpJsonResponseMessage(object data) {
            string content = JsonConvert.SerializeObject(data, Formatting.None);
            Content = new StringContent(content, Encoding.UTF8, MediaTypes.Json);
        }

        public HttpJsonResponseMessage(object data, Formatting formatting) {
            string content = JsonConvert.SerializeObject(data, formatting);
            Content = new StringContent(content, Encoding.UTF8, MediaTypes.Json);
        }

        public HttpJsonResponseMessage(object data, Formatting formatting, JsonSerializerSettings settings) {
            string content = JsonConvert.SerializeObject(data, formatting, settings);
            Content = new StringContent(content, Encoding.UTF8, MediaTypes.Json);
        }

        public HttpJsonResponseMessage(object data, Formatting formatting, JsonContractResolver contractResolver) {

            JsonSerializerSettings settings = new JsonSerializerSettings {
                ContractResolver = contractResolver
            };

            string content = JsonConvert.SerializeObject(data, formatting, settings);

            Content = new StringContent(content, Encoding.UTF8, MediaTypes.Json);

        }

    }

}