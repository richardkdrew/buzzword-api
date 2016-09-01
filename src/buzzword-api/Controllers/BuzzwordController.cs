using BuzzwordApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BuzzwordApi.Controllers
{
    [Route("api/buzzwords")]
    public class BuzzwordController
    {
        private static IBuzzwordServiceClient _buzzwordServiceClient;
        public BuzzwordController(IBuzzwordServiceClient buzzwordServiceClient)
        {
            _buzzwordServiceClient = buzzwordServiceClient;
        }

        [HttpGet]
        public async Task<JsonResult> Get(string category)
        {
            bool failed = false;
            var randomWord = string.Empty;
            var service = string.Empty;
            
            try 
            {                  
                // Get a list of buzzwords for a given category          
                var buzzwordResponse = await _buzzwordServiceClient.GetBuzzwordsByCategory(category).ConfigureAwait(false);   

                var buzzwords = buzzwordResponse.Buzzwords;  
                service = buzzwordResponse.ServiceId;                        

                // Select a random one
                Random r = new Random();               
                randomWord = buzzwords[r.Next(0, buzzwords.Length)];
            }  
            catch
            {
                failed = true;                
            }        
          
            return new JsonResult(new {
                buzzword = randomWord,
                category = category,
                apiId = Environment.MachineName,
                serviceId = service,
                error = failed
            });                   
        }
    }
}
