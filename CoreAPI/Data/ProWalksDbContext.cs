
using CoreAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Data
{
    public class ProWalksDbContext : DbContext
    {

        /*
            Dbcontextoptions is a class in EF that carries the configuration informaiton required to 
           to create and configute the DBContext :

               1. DB provider
               2. connection string
               3. Logging 
         */

        public ProWalksDbContext(DbContextOptions options) : base(options)
        {

        }


        //DBSets  // colletion of entities of a specific type
                  // Act like a bridge b/w the your entityclass and the database
                  // Perform the CRUD operions(Create , read , update , delete)


        public DbSet<Region> Region { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }

        public DbSet<Walks> Walks { get; set; }





    }
}



// We have to interact with DB

// For we need to create the DB 
// interact DB

//Steps:
// 1. Create a prowalks project
// 2. Project domain models
// 3. Add EF packages 
// 4. DB Context
// 5. Add a connection string
// 6. run EF for migrations ( we can push the DBcontext into the DB)
       // Add-Migration "Initial Migration"
       // update-database( few seconds check db)
// 7. Test the DB availble or not in SQLServer




