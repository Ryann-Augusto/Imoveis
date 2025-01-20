using AspNetCore;
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
            builder.Entity<MdUsuarios>().HasData(
                new MdUsuarios
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Nome = "Admin",
                    Cpf_Cnpj = "00000000000",
                    Telefone = "00000000000",
                    Senha = "123456",
                    ConfirmSenha = "123456",
                    Nivel = 1,
                    Situacao = 1,
                });

        }

        public DbSet<MdImoveis> Imovel { get; set; }
        public DbSet<MdUsuarios> Usuario { get; set; }
        public DbSet<MdImagens> Imagem { get; set; }

    }
}
