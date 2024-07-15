using CoreAPI.Data;
using CoreAPI.Domain;
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

        public RegionsController(ProWalksDbContext _prowalksDbContext) {
            this.proWalksDbContext = _prowalksDbContext;
        }

        // I want the data from Region which is in the database

        // 1. DBContext in the RegionsController
        //      (DbContext talk to the database)

        // 1. you have to connect with Dbcontext  key role

        // I want to get all the regions List

        // i am going to prepare the one method i.e. Get

        [HttpGet]
        public IActionResult GetAllRegions()
        {

           var regions =  proWalksDbContext.Regions.ToList();
            
            ////var regions = new List<Region>
            //{
            //    new Region()
            //    {
            //        Id = Guid.NewGuid(),
            //        Area = 2000000,
            //        Lat = 19.099999,
            //        Long = 20.0000,
            //        Name = "Hindu",
            //        Code = "Hn",
            //        population = 100000
            //    },

            //    new Region()
            //    {
            //        Id = Guid.NewGuid(),
            //        Area = 1000000,
            //        Lat = 9.099999,
            //        Long = 20.0010,
            //        Name = "Sikkus",
            //        Code = "Si",
            //        population = 2000
            //    }
            //};
            return Ok(regions);
        }



        // I want to fetch the Religion based on the ID


        //https://localhost/7078/api/Region/{regionid}
        [HttpGet]
        [Route("{regionId:Guid}")]
        public IActionResult GetRegionById([FromRoute] Guid regionId)
        {

            //var id = regionId;


            var regions = proWalksDbContext
                .Regions.Find(regionId);

            if(regions == null)
            {
                return BadRequest();
            }

            
            return Ok(regions);
        }




    }
}
