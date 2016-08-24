using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;

namespace BuzzwordApi.Controllers
{
    [Route("api/buzzword")]
    public class BuzzwordController
    {
        [HttpGet]
        public JsonResult Get(string category)
        {
            bool failed = false;
            var randomWord = string.Empty;
            var selectedCategory = string.IsNullOrEmpty(category) ? "General" : category; 
            
            try 
            {                  
                // Get a list of buzzwords for a given category          
                var buzzwords = GetBuzzwords(category);                             

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
                category = selectedCategory,
                apiId = Environment.MachineName,
                error = failed
            });           
        }

        private string[] GetBuzzwords(string category)
        {
            try 
            {
                // Call the buzzword service
                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://192.168.99.100:5000")
                };   

                // Sort out the response
                var response = client.GetAsync(string.Format("buzzwords?category={0}", category));  

                if(response.Result.StatusCode != HttpStatusCode.OK) throw new Exception();

                var content = response.Result.Content;

                var buzzwords = content.ReadAsAsync<List<string>>();

                return buzzwords.Result.ToArray();
            }
            catch 
            {
                throw new Exception("There were problems calling the Buzzword Service");
            }                          
        }
    }
}
