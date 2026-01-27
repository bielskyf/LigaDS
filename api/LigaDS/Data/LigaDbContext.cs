using LigaDS.Models;
using Microsoft.EntityFrameworkCore;

namespace LigaDS.Data
{
    public class LigaDbContext : DbContext
    {
        public LigaDbContext(DbContextOptions<LigaDbContext> options) : base(options)
        {
        }

        public DbSet<Liga> Ligas { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Atleta> Atletas { get; set; }

    }
}
