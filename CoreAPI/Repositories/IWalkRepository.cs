using CoreAPI.Domain;

namespace CoreAPI.Repositories
{
    public interface IWalkRepository
    {
       Task<List<Walk>> GetAllWalkAsync();
    }
}
