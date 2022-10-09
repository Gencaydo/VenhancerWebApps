using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace Venhancer.Crowd.Shared.Services
{
    public static class CallAPIService
    {
        public static async Task<string> CallPostAPI(string _apiUrl,object _postobject,string apiBaseUrl)
        {
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
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
