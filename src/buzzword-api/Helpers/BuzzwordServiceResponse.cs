namespace BuzzwordApi.Helpers
{
    public class BuzzwordsServiceResponse
        {
            public BuzzwordsServiceResponse(string[] buzzwords, string category, string serviceId)
            {
                Buzzwords = buzzwords;
                Category = category;
                ServiceId = serviceId;
            }

            public string[] Buzzwords { get; private set; }
            public string Category { get; private set; }
            public string ServiceId { get; private set; }

        }
}