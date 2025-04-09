using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskDoner.Data
{
    public class TaskAuthDbContext : IdentityDbContext
    {
        public TaskAuthDbContext(DbContextOptions<TaskAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "ef523a22-0111-4c4b-a45a-8e99ea57fc27";
            var writerRoleId = "aab8af9e-33aa-4a2c-82d6-d384859a721c";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Write".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }


    }
}
