﻿using CoreAPI.Domain;

namespace CoreAPI.DTOs
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }


        public Region region { get; set; }
        public WalkDifficulty walkDifficulty { get; set; }


    }
}
