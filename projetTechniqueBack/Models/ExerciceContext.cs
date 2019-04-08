using Microsoft.EntityFrameworkCore;

namespace projetTechniqueBack.Models
{
    public class ExerciceContext : DbContext
    {
        public ExerciceContext(DbContextOptions<ExerciceContext> options) : base(options)
        {

        }

        public DbSet<ExerciceItem> ExerciceItems { get; set; }
    }
}
