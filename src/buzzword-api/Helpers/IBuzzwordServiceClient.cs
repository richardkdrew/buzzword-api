using System.Threading.Tasks;

namespace BuzzwordApi.Helpers
{
    public interface IBuzzwordServiceClient
    {
        Task<BuzzwordsServiceResponse> GetBuzzwordsByCategory(string category);
    }
}