namespace BuzzwordApi.Helpers
{
    public class PoliticsBuzzwordHelper : IBuzzwordHelper
    {
        public string[] GetBuzzwords()
        {
            return new string[] {
                "Big society",
                "Information society",
                "Political capital",
                "Statist",
                "Stakeholder"
            };
        }
    }
}