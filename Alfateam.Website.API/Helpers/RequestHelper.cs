using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Net;

namespace Alfateam.Website.API.Helpers
{
    public static class RequestHelper
    {

        public static void SetBearerToken(string token)
        {
            _token = token;
        }

        public static void AddDefaultHeaders(IEnumerable<KeyValuePair<string, string>> headers)
        {
            _headers = headers;
        }

        public static void ClearDefaultHeaders()
        {
            _headers = null;
        }

        public static EventHandler OnUnauthorized;

        private static string _token;
        private static IEnumerable<KeyValuePair<string, string>> _headers;

        public static async Task<RestResponse> ExecuteRequestAsync(
            string url,
            Method method,
            object body = null)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"{url}");

                var options = new RestClientOptions(url)
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                };
                RestClient client = new RestClient(options);

                var request = new RestRequest(url, method);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                if (!string.IsNullOrEmpty(_token))
                {
                    request.AddHeader("Authorization", "Bearer " + _token);
                }

                if (_headers != null)
                {
                    foreach (var header in _headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }

                if (body is not null)
                    request.AddJsonBody(body);

                CancellationToken cancellationToken = new CancellationToken();

                var resp = await client.ExecuteAsync(request, cancellationToken);

                if (resp.StatusCode == HttpStatusCode.Unauthorized)
                {
                    OnUnauthorized?.Invoke(null, null);
                }

                if (resp.ErrorException != null)
                {
                    Console.WriteLine(resp.ErrorException);
                    throw resp.ErrorException;
                }

                return resp;
            }
            catch (Exception e)
            {
                return new RestResponse()
                {
                    ErrorMessage = e.Message,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

        }

        public static async Task<T> ExecuteRequestReceiveModelAsync<T>(string url, Method method,
            object dto = null)
        {
            try
            {
                var response = await RequestHelper.ExecuteRequestAsync(url, method, dto);

                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return default;
        }
    }
}
