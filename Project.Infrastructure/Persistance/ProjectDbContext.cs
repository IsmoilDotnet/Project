using Microsoft.EntityFrameworkCore;

namespace Project.Infrastructure.Persistance
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Project.Domain.Entities.Models.User> Users { get; set; }
    }
}
