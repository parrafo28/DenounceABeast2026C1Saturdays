using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }

        public DbSet<Entities.Municipality> Municipalities { get; set; }
        public DbSet<Entities.Sector> Sectors { get; set; }
        public DbSet<Entities.ComplaintType> ComplaintTypes { get; set; }
        public DbSet<Entities.Status> Status { get; set; } 
    }
}
