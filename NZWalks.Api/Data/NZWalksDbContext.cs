﻿using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Model.Domain;

namespace NZWalks.Api.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions <NZWalksDbContext> dbContextOptions):base(dbContextOptions) 
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
