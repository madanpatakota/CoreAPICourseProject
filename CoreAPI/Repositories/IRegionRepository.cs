using CoreAPI.Domain;
using CoreAPI.DTOs;

namespace CoreAPI.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAllRegions();

        public Task<Region> CreateRegion(Region region);

        public Task<Region> GetRegionByID(Guid regionId);

       

        public Task<Region> UpdateRegion(Guid id , Region region);

        public Task<Region> DeleteRegion(Region region);


    }
}
