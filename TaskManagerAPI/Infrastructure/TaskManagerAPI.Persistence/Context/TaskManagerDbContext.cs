using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagerAPI.Domain.Entities;
using TaskManagerAPI.Domain.Entities.Identity;

namespace TaskManagerAPI.Persistence.Context
{
    public class TaskManagerDbContext: IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<Duty> Duties { get; set; }
        public TaskManagerDbContext()
        {
            
        }
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Duty>()
               .Property(d => d.Status)
               .HasConversion<string>();

            builder.Entity<AppRole>()
               .HasData(new AppRole()
               {
                   Id = Guid.NewGuid(),
                   Name = "user",
                   ConcurrencyStamp = Guid.NewGuid().ToString(),
                   NormalizedName = "USER",
               });
        }


    }
}
