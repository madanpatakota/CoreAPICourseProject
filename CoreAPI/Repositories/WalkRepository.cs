using CoreAPI.Data;
using CoreAPI.Domain;
using CoreAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {

        //declration
        private readonly ProWalksDbContext _proWalksDbContext;
        public WalkRepository(ProWalksDbContext context)
        {
            _proWalksDbContext = context;
            ;
        }

        public async Task<List<Walk>> GetAllWalkAsync()
        {
            // r u getting your desire data from DB?
            List<Walk> walks = await _proWalksDbContext.Walks
                                                         .Include("Region")
                                                         .Include("walkDifficulty")
                                                         .ToListAsync();


            // List<string> strings = new List<string>() { "xy", "John", "robert", "Deaddds" };

            //  Lambda expression or arrow function
            //  strings.Where(x=>x.Length > 3).ToList();

            // Question) i want to get the john record


            //strings.Find(x => x == "John");



            //

            //5 count

            //1 record


            //My Team Leader just pass he 

            // Data filter is the important

            //List<Walk> TakeOneRecord =  walks.Take(1).ToList();

            //Walk filterWalks = walks.Find(x => x.Length == 10.5);

            List<Walk> WhereMorethanLength10 = walks.Where(x => x.Length > 10).ToList();

            List<Walk> keralaRecords = walks.
                Where(x => x.Name == "Walk in Kerala").ToList();

            // Let me see what is the data getting.


            //if(keralaRecords.Count > 0)
            //{
            //    return true;
            //}
            //else { false; }


            return keralaRecords;
        }


        //Task<bool> CreateWalkAsync(AddWalkDTO addWalkDTO);
        public async Task<bool> CreateWalkAsync(AddWalkDTO addWalkDTO)
        {
            try
            {
                Walk walk = new Walk();
                walk.Name = addWalkDTO.Name;
                walk.WalkDifficultyId = addWalkDTO.WalkDifficultyId;
                walk.Length = addWalkDTO.Length;
                walk.RegionId = addWalkDTO.RegionId;

                await _proWalksDbContext.Walks.AddAsync(walk);
                await _proWalksDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Guid> UpdateWalkAsync(Guid id, UpdateWalkDTO updateWalkDTO)
        {

            //_proWalksDbContext.Walks.Find(id);
            Walk walk = await _proWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walk != null)
            {
                walk.Length = updateWalkDTO.Length;
                walk.RegionId = updateWalkDTO.RegionId;
                walk.WalkDifficultyId = updateWalkDTO.WalkDifficultyId; ;
                walk.Name = updateWalkDTO.Name;

                _proWalksDbContext.Walks.Update(walk);

                await _proWalksDbContext.SaveChangesAsync();
                return id;
            }
            else
            {
                return Guid.Empty; //00000000 - 0000 - 0000 - 0000 - 000000000000.
            }
        }


       public async Task<string> DeleteWalkAsync(Guid id)
        {

            Walk walk = await _proWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walk != null)
            {

                //Add remove Update Get
                _proWalksDbContext.Walks.Remove(walk);
                await _proWalksDbContext.SaveChangesAsync();
                return "Success";
            }
            else
            {
                return "Fail"; 
            }

        }



    }
}
