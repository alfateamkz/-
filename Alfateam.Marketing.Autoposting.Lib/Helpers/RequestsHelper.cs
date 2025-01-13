using Alfateam.Marketing.Autoposting.Lib.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Helpers
{
    public static class RequestsHelper
    {

        //public static async Task MakeRequestAndThrowIfNotSuccess(string url, Method method, int expectedStatusCode = 200, object body = null)
        //{
        //    var response = await MakeRequest(url, Method.Get);
        //    if ((int)response.StatusCode != expectedStatusCode)
        //    {
        //        throw new AutoposterApiErrorException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
        //    }
        //}
        //public static async Task<T> MakeRequestAndThrowIfNotSuccess<T>(string url, Method method, object body = null)
        //{
        //    var response = await MakeRequest(url, Method.Get);
        //    return ParseSuccessJSONOrThrowError<T>(response);
        //}

        public static async Task<RestResponse> MakeRequestAsJson(string url, Method method, object body = null, Dictionary<string, string> headers = null)
        {
            return await MakeRequest(url, method, true, body, headers);
        }

        public static async Task<RestResponse> MakeRequestAsForm(string url, Method method, object body = null, Dictionary<string, string> headers = null)
        {
            return await MakeRequest(url, method, false, body, headers);
        }

        public static async Task<RestResponse> MakeRequestAsFormFileUpload(string url, Method method, Dictionary<string,string> files, object body = null, Dictionary<string, string> headers = null)
        {
            var req = new RestRequest
            {
                Method = method,
                Resource = url,
            };
            req = req.AddHeader("Content-Type", "multipart/form-data");

            if (body != null)
            {
                req = req.AddBody(body);
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    req = req.AddHeader(header.Key, header.Value);
                }
            }

            foreach (var file in files)
            {
                req = req.AddFile(file.Key, file.Value);
            }

            return await new RestClient().ExecuteAsync(req);
        }

        private static async Task<RestResponse> MakeRequest(string url, Method method, bool isJson, object body = null, Dictionary<string, string> headers = null)
        {
            var req = new RestRequest
            {
                Method = method,
                Resource = url,
            };

            if (isJson)
            {
                req = req.AddHeader("Content-Type", "application/json");
            }
            else
            {
                req = req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            }


            if (body != null)
            {
                req = req.AddBody(body);
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    req = req.AddHeader(header.Key, header.Value);
                }
            }

            return await new RestClient().ExecuteAsync(req);
        }
    }
}
