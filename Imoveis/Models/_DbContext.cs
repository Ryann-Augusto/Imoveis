using Microsoft.EntityFrameworkCore;

namespace Imoveis.Models
{
    public class _DbContext: DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
            { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<Imoveis> Imovel { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }

    }
}
