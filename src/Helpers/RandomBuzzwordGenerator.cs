using System;

namespace BuzzwordApi.Helpers
{
    public static class RandomBuzzwordGenerator
    {
        public static string GetRandomBuzzword(string category) 
        {
            Random r = new Random();

            string[] words = GetHelper(category).GetBuzzwords();

            return words[r.Next(0, words.Length)];
        }

        private static IBuzzwordHelper GetHelper(string category)
        {
            switch(category.ToLower())
            {
                case "technology":
                    return new TechnologyBuzzwordHelper();
                case "politics":
                    return new PoliticsBuzzwordHelper();
                case "education":
                    return new EducationBuzzwordHelper();
                case "general":                    
                    return new GeneralBuzzwordhelper();
                default:
                    throw new Exception("Unrecognised buzzword category");
            }            
        }
    }
}