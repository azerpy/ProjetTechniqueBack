using Microsoft.EntityFrameworkCore;

namespace projetTechniqueBack.Models
{
    public class EvenementContext : DbContext
    {
        public EvenementContext(DbContextOptions<EvenementContext> options) : base(options)
        {

        }

        public DbSet<EvenementItem> EvenementItems { get; set; }
    }
}
