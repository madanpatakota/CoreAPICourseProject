using CoreAPI.Data;
using CoreAPI.Domain;
using CoreAPI.DTOs;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Controllers
{


    //https://localhost:7000/api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly ProWalksDbContext proWalksDbContext;
        private readonly IRegionRepository iregionRepository;

        public RegionsController(ProWalksDbContext _prowalksDbContext ,
            IRegionRepository regionRepository) {
            this.proWalksDbContext = _prowalksDbContext;
            this.iregionRepository = regionRepository;
        }

        // I want the data from Region which is in the database

        // 1. DBContext in the RegionsController
        //      (DbContext talk to the database)

        // 1. you have to connect with Dbcontext  key role

        // I want to get all the regions List

        // i am going to prepare the one method i.e. Get


        
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {


            //1. YOu should not maintain the dbcontext directly in to the controller 
            //    i.e. bad practice. // 1. Maintaince 2.Testability

            //2. you should be communicated to the interface not the class

            //from the controller
            //please do' try to connect the databasecontext
            //  3 records

            //var regions = await proWalksDbContext.Regions.ToListAsync();
            var regions = await iregionRepository.GetAllRegions();

            // i have to connect the 


            //IRegionReposity rep = new RegionRepository();
            //rep.GetAllRegions();
            

                   var regionDtos = new List<RegionDTO>();

            foreach (var region in regions)
            {
                regionDtos.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    Lat = region.Lat,
                    Long = region.Long,
                    Area = region.Area,
                    population = region.population
                });
            }
            return Ok(regionDtos);
        }



        // I want to fetch the Religion based on the ID
        //https://localhost/7078/api/Region/{regionid}

        [HttpGet]
        [Route("{regionId:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid regionId)
        {

            //string str = "Hellow";

            //return Ok(str);

            //var id = regionId;

            //var regions =  proWalksDbContext
            //   .Regions.Find(regionId);
            //var regions = await proWalksDbContext
            //    .Regions.FindAsync(regionId);
            var regions = await iregionRepository.GetRegionByID(regionId);

            if (regions == null)
            {
                return BadRequest();
            }


            var regionDto = new RegionDTO();

            regionDto.Id = regions.Id;
            regionDto.Code = regions.Code;
            regionDto.Name = regions.Name;
            regionDto.Lat = regionDto.Lat;
            regionDto.Lat = regions.Lat;
            regionDto.population = regions.population;
            regionDto.Area = regions.Area;


            return Ok(regionDto);
        }


        // 1. Real time 
        // you will receive the region information from clinet who has requested to you
        // Front end
        // Insert | Create

        //informaiton like customeid cusotmerlocation abhiid id , jdate 

        //public Iaction

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDto addRegionDto)
        {

            var regionDomainModel = new Region
            {
                Code = addRegionDto.Code,
                Name = addRegionDto.Name,
                Lat = addRegionDto.Lat,
                Long = addRegionDto.Long,
                Area = addRegionDto.Area,
                population = addRegionDto.population
            };

            await iregionRepository.CreateRegion(regionDomainModel);

            //await proWalksDbContext.Regions.AddAsync(regionDomainModel);
            //proWalksDbContext.SaveChanges();


            //Map domain model back to the DTO

            //return Ok("no i wou't the response");

            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name
            };

            // regionDto.Id = regionDomainModel.Id;
            /// Prepare the code..

            return Ok(regionDto);

        }



        // Update ---> you will update the records based on the key(Id)


        [HttpPut]
        [Route("{regionId:Guid}")]
        //6FDBC8DC-2B84-4747-F588-08DCA54EDBAF
        // Code : "Siks" , Area : 1000 , Name : "SN" , Lat : 100.09
        public async Task<IActionResult> updateRegion(
             [FromRoute] Guid regionId,
             [FromBody]  UpdateRegionDto updateRegionDto)
        {
            var regionDomainModel = await proWalksDbContext.Regions.FindAsync(regionId);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            regionDomainModel.Code = updateRegionDto.Code;  // Siks
            regionDomainModel.population = updateRegionDto.population;
            regionDomainModel.Area = updateRegionDto.Area;
            regionDomainModel.Lat = updateRegionDto.Lat;
            regionDomainModel.Long = updateRegionDto.Long;
            regionDomainModel.Name = updateRegionDto.Name;
            //no need the add.

            Region region = 
                await iregionRepository.UpdateRegion(regionId , regionDomainModel);

            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name
            };

            return Ok(regionDto);

        }

        //On which key(ID) you are going to delete
        [HttpDelete]
        [Route("{regionId:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid regionId)
        {

            var regionDomainModel = await proWalksDbContext.Regions.FindAsync(regionId);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            await iregionRepository.DeleteRegion(regionDomainModel);
            //proWalksDbContext.Regions.Remove(regionDomainModel);
            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name
            };

            return Ok(regionDto);



        }



    }
}
