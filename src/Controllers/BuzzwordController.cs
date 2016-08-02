using BuzzwordApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

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
                       
            try {
                randomWord = RandomBuzzwordGenerator.GetRandomBuzzword(selectedCategory);
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
    }
}
