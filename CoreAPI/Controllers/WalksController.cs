using CoreAPI.Domain;
using CoreAPI.DTOs;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {


        private readonly IWalkRepository _walkRepository;
        public WalksController(IWalkRepository walkRepository) {
            _walkRepository = walkRepository;
        }



        //Which interface you have to import
        //

        //GetAllWalks Information

        [HttpGet]

        public async Task<IActionResult> getAllWalks()
        {

            //IWalkRepository walk = new WalkRepository(null);

            //WalkRepository walk1 = new WalkRepository(null, "test", 0);

            List<Walk>  walks =  await _walkRepository.GetAllWalkAsync();

            //walkDTO

            List<WalkDTO> walkDTOs = new List<WalkDTO>();

            //WalkDTO dto = new WalkDTO({ Name = "" ,})

            //List<string> strs = new List<string>();
            //strs.Add("axyx");


            foreach(Walk walk in walks)
            {
                //walkDTOs.Add(new WalkDTO { });

                walkDTOs.Add(new WalkDTO
                {
                    Id = walk.Id,
                    Name = walk.Name,
                    Length = walk.Length,
                    RegionId = walk.RegionId,
                    WalkDifficultyId = walk.WalkDifficultyId
                });
            }
            return Ok(walkDTOs);
        }
    }
}
