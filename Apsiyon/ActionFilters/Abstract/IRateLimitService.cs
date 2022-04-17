using System.Threading.Tasks;

namespace Apsiyon.ActionFilters.Abstract
{
    public interface IRateLimitService
    {
        Task<bool> HasAccessAsync(string resourceKey, int periodInSec, int limit);
    }
}
