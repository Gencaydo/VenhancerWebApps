using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers;
using System.Net;
using Venhancer.Crowd.Shared.Dtos;

namespace Venhancer.Crowd.Shared.Services
{
    public static class CallAPIService
    {
        public static async Task<string> CallTokenAPI(string apiBaseUrl, string _apiUrl, LoginDto _loginDto)
        {
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
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
        public static async Task<string> CallPostAPI(string apiBaseUrl, string _apiUrl, object _postobject, string token)
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
    }
}
