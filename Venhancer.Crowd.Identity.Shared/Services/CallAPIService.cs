using AutoMapper.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Serializers.Json;
using System.Net;
using System.Net.Security;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.Shared.Services
{
    public static class CallAPIService
    {
        //private static bool RemoteServerCertificateValidationCallback(object sender,X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //{
        //    return true;
        //}
        public static async Task<string> CallTokenAPI(string apiBaseUrl, string _apiUrl, LoginDto _loginDto)
        {
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
                //client.Options.RemoteCertificateValidationCallback += new RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                var request = new RestRequest();
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("accept", "application/json; charset=utf-8");
                var body = JsonConvert.SerializeObject(_loginDto);
                request.AddStringBody(body, ContentType.Json);
                var response = await client.ExecutePostAsync(request);

                return response.Content;               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> CallAuthorizationAPI(string apiBaseUrl, string _apiUrl,object _postobject, string token)
        {
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
                var request = new RestRequest();
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("authorization", "Bearer " + token);
                request.AddHeader("accept", "application/json; charset=utf-8");
                var body = JsonConvert.SerializeObject(_postobject);
                request.AddStringBody(body, ContentType.Json);
                var response = await client.ExecutePostAsync(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task<string> CallAPI(string apiBaseUrl, string _apiUrl, object _postobject, string token, Method method)
        {
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
                var request = new RestRequest();
                var response = new RestResponse();
                var body = "";               
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("authorization", "Bearer " + token);
                request.AddHeader("accept", "application/json; charset=utf-8");

                if (_postobject != null)
                {
                    body = JsonConvert.SerializeObject(_postobject);
                    request.AddStringBody(body, ContentType.Json);                  
                }

                if (method == Method.Post) response = await client.ExecutePostAsync(request);
                else if (method == Method.Get) response = await client.ExecuteGetAsync(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
