using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace BuzzwordApi.Helpers
{
    public class BuzzwordServiceClient : IBuzzwordServiceClient
    {
        private static string buzzwordServiceBaseUrl = @"http://192.168.99.100:5000";
        private static string getBuzzwordsByCategoryPathTemplate = @"/buzzwords/{0}";

        public Task<BuzzwordsServiceResponse> GetBuzzwordsByCategory(string category)
        {
            var response = RequestBuzzwordsByCategory(category).ConfigureAwait(false);
            return ConvertToBuzzwords(response.GetAwaiter().GetResult());
        }

        private static async Task<HttpResponseMessage> RequestBuzzwordsByCategory(string category)
        {
            var buzzwordsResource = string.Format(getBuzzwordsByCategoryPathTemplate, category);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(buzzwordServiceBaseUrl);
                return await httpClient.GetAsync(buzzwordsResource).ConfigureAwait(false);
            }
        }

        private static async Task<BuzzwordsServiceResponse> ConvertToBuzzwords(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<BuzzwordsServiceResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }        
    }         
}