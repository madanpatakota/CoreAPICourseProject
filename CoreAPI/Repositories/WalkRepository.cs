using CoreAPI.Data;
using CoreAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {

        //declration
        private readonly ProWalksDbContext _proWalksDbContext;
        public WalkRepository(ProWalksDbContext context) {
            _proWalksDbContext = context;
;        }

        public async Task<List<Walk>> GetAllWalkAsync()
        {
            List<Walk> walks  = await  _proWalksDbContext.Walks.ToListAsync();
            return walks;
        }
    }
}
