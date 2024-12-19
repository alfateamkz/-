using Alfateam.SMSGateways.Countries.Russia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Helpers
{
    public static class RequestsHelper
    {
        public static async Task<Response<T>> Send<T>(HttpMethod method, string url, object body = null)
        {
            using (HttpClient client = new HttpClient())
            {
                var message = new HttpRequestMessage(method, url);
                if(body != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(body));
                }

                var response = await client.SendAsync(message);
                return new Response<T>
                {
                    Data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()),
                    StatusCode = (int)response.StatusCode
                };
            }
        }
    }

    public class Response<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
