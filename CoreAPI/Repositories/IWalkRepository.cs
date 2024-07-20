using CoreAPI.Domain;
using CoreAPI.DTOs;

namespace CoreAPI.Repositories
{
    public interface IWalkRepository
    {
       Task<List<Walk>> GetAllWalkAsync();

        Task<bool> CreateWalkAsync(AddWalkDTO addWalkDTO);


        Task<Guid> UpdateWalkAsync(Guid id , UpdateWalkDTO updateWalkDTO);

        Task<string> DeleteWalkAsync(Guid id);



    }
}
