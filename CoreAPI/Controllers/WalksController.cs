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
                    WalkDifficultyId = walk.WalkDifficultyId,
                    region = walk.Region,
                    walkDifficulty = walk.walkDifficulty
                });
            }
            return Ok(walkDTOs);
        }



        [HttpPost]
        //[Route("MyOwnCreateWalk")]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkDTO addWalkDTO)
        {

            //Monitor As the backdeveloper focus on the input parameter -- completed


            //Then pass the information to the Respective method.
            // 1. you have to decide on which method you have to connect . You have to 
            //  search

           bool response =  await _walkRepository.CreateWalkAsync(addWalkDTO);


            //So once you receive the informaiton from that recepecive method
            //Incase data woul't be availeble or exceptions 
            if (response)
            {
                return Ok("Success!!!! Data has inserted.");
            }
            else
            {
                return BadRequest();
            }

            //then prepare the DTO(ResponseDTO -- Take decision)


            //Will write the Business


        }




        //i want to update the record based on the ID -- from address you are getting the ID
        //you will get the record 

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id ,
            [FromBody] UpdateWalkDTO updateWalkDTO)
        {
            //which method you have to connect

            Guid responseID = await _walkRepository.UpdateWalkAsync(id, updateWalkDTO);
            
            if(responseID  != Guid.Empty)
            {
                string ouput = " Updated successfully and your id is" + responseID;
                return Ok(ouput);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            //which method you have to connect
            string response = await _walkRepository.DeleteWalkAsync(id);
            return Ok(response);
        }

    }
}
