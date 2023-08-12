using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulties
            //Easy, Medium, Hard 

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("a43a7986-9ea6-4deb-9d41-31cd4dcc1357"),
                    Name = "Easy",

                },
                new Difficulty()
                {
                    Id = Guid.Parse("bd885d12-0d59-4c88-88ef-38cfdc44c830"),
                    Name = "Medium",

                },
                new Difficulty()
                {
                    Id = Guid.Parse("0e9fec06-0a14-407d-8367-48582c3bdbe0"),
                    Name = "Hard",

                },
            };
            //seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed data for regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("40919be2-f663-41d3-90f4-a2511b364fa2"),
                    Name = "Abuja",
                    Code = "ABJ",
                    RegionImageUrl = null

                },
                new Region()
                {
                    Id= Guid.Parse("bbf2f790-6c74-4cd2-84bc-62d178335519"),
                    Name = "Kaduna",
                    Code = "KD",
                    RegionImageUrl = null

                },
                new Region()
                {
                    Id = Guid.Parse("57c3476f-5148-4822-a1b4-98fbac347e8a"),
                    Name = "Makurdi",
                    Code = "MKD",
                    RegionImageUrl = null
                },

            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
