using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "c2a0b5f1-5b8d-4f0d-8e73-6e14d1b0d8c1";
            var writerRoleId = "e8f4f0ce-9ad2-4f41-9f2d-2c826a2b0f55";

            var roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Id=readerRoleId,
                    ConcurrencyStamp= readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                  new IdentityRole{
                    Id=writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}