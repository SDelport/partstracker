using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace PartsTracker.Models
{
    public class PartsContext(DbContextOptions<PartsContext> options) : DbContext(options)
    {
        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>().HasData(
                new Part
                {
                    PartNumber = "P_001",
                    Description = "Screen with atleast 2.5 HDMI Ports",
                    QuantityOnHand = 31,
                    LocationCode = "pta-2",
                    LastStockTake = new DateTime(2025,06,30,8,0,0).ToUniversalTime()
                },
                new Part
                {
                    PartNumber = "P_002",
                    Description = "Mouse that is both wireless, and not",
                    QuantityOnHand = 29,
                    LocationCode = "pta-1",
                    LastStockTake = new DateTime(2025, 06, 30, 8, 0, 0).ToUniversalTime()
                },
                new Part
                {
                    PartNumber = "P_003",
                    Description = "Keyboard with 16 additional keys",
                    QuantityOnHand = 3,
                    LocationCode = "jhb-1",
                    LastStockTake = new DateTime(2025, 06, 30, 8, 0, 0).ToUniversalTime()
                }
            );
        }
    }
}
