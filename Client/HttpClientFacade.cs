using System;
using System.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.ApplicationServer.Http;
using Services.Contract.Requests;
using Services.Contract.Responses;

namespace Client
{
    public class HttpClientFacade
    {
        #region old
        public dynamic GetJson(string url)
        {
            var response = GetJsonResponse(url);
            var jsonObject = response.Content.ReadAs<JsonValue>();
            return jsonObject.AsDynamic();
        }

        public dynamic PostJson<TContext>(string url, TContext postContent)
        {
            throw new NotImplementedException();
        }

        private static HttpResponseMessage GetJsonResponse(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client.Send(request);
        }
        #endregion

        public static TResponse GetJson<TResponse>(string url)
        {
            var content = Get(url, JsonMediaTypeFormatter.DefaultMediaType);
            return content.ReadAs<TResponse>();
        }

        public static TResponse PostJson<TRequest, TResponse>(string url, TRequest request)
        {
            return Post<TRequest, TResponse>(url, request, JsonMediaTypeFormatter.DefaultMediaType);
        }

        public static TResponse GetXml<TResponse>(string url)
        {
            var content = Get(url, XmlMediaTypeFormatter.DefaultMediaType);
            return content.ReadAs<TResponse>();
        }

        public static TResponse PostXml<TRequest, TResponse>(string url, TRequest request)
        {
            return Post<TRequest, TResponse>(url, request, XmlMediaTypeFormatter.DefaultMediaType);
        }

        private static HttpContent Get(string url, MediaTypeHeaderValue headerValue)
        {
            using(var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(headerValue.MediaType));
                var response = client.Send(request);
                return response.Content;
            }
        }

        private static TResponse Post<TRequest, TResponse>(string url, TRequest request, MediaTypeHeaderValue headerValue)
        {
            using (var client = new HttpClient())
            {
                var objectContent = new ObjectContent<TRequest>(request, headerValue);
                var response = client.Post(url, objectContent);
                return response.Content.ReadAs<TResponse>();
            }
        }
    }
}