using CoreAPI.Data;
using CoreAPI.Domain;
using CoreAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CoreAPI.Repositories
{

    /*
     *  IRegionReposity rep = new RegionRepository();
     *  rep.GetAllRegions();
     *  
     *  RegionRepository regionRepository = new RegionRepository();
     *  
     */

    ////


    ////RegionRepository regionRepository = new RegionRepository();
    ////regionRepository.GetAllRegions
    public class RegionRepository : IRegionRepository
    {

        ProWalksDbContext _proWalksDbContext;
        public RegionRepository(ProWalksDbContext proWalksDbContext) {
            this._proWalksDbContext = proWalksDbContext;
        }

        public async Task<Region> CreateRegion(Region region)
        {
            
            await _proWalksDbContext.Regions.AddAsync(region);
            _proWalksDbContext.SaveChanges();

            return region;
        }

        public async Task<Region> DeleteRegion(Region regionDomainModel)
        {
             _proWalksDbContext.Regions.Remove(regionDomainModel);
            await _proWalksDbContext.SaveChangesAsync();
            return regionDomainModel;
        }

        //public Task<Region> DeleteRegion(string regionId)
        //{
        //    throw new NotImplementedException();
        //}

        //public string abc()
        //{
        //    return "hellow";
        //}

        //var regions = await proWalksDbContext.Regions.ToListAsync();

        public async Task<List<Region>> GetAllRegions()
        {
            return await this._proWalksDbContext.Regions.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Region> GetRegionByID(Guid regionId)
        {
            return await _proWalksDbContext.Regions.FindAsync(regionId);
        }

        public async Task<Region> UpdateRegion(Guid id, Region updateRegionDto)
        {
            await _proWalksDbContext.SaveChangesAsync();
            return updateRegionDto;
        }
    }
}
