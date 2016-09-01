using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuzzwordApi.Helpers
{
    public interface IBuzzwordServiceClient
    {
        Task<List<string>> GetBuzzwordsByCategory(string category);
    }
}