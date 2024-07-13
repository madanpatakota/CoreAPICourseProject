namespace CoreAPI.Domain
{
    public class Walks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        
        public Guid WalkDifficultyId { get; set; }


        // Navigation Properties ( which Entites you would to like merge | work | want)

        
        public Region Region { get; set; }

        public WalkDifficulty  walkDifficulty { get; set; }
        

        
        // Merge 


        //Future

        //Onlineshopping style

        //Products and Customers models

        // I want ot get the ProductID and along with CustomerName

        // YOu need to merge the Products and Customers --> Prepare the data



    }
}
