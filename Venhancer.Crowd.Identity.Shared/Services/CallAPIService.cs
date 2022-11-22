using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.Shared.Services
{
    public static class CallAPIService
    {
        public static async Task<string> CallAPI(string apiBaseUrl, string _apiUrl, object _postobject, string token, Method method)
        {
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
                var request = new RestRequest();
                var response = new RestResponse();              
                request.AddHeader("cache-control", "no-cache");
                if (!string.IsNullOrEmpty(token)) request.AddHeader("authorization", "Bearer " + token);
                request.AddHeader("accept", "application/json; charset=utf-8");

                if (_postobject != null)
                {
                    var body = JsonConvert.SerializeObject(_postobject);
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
