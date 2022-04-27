using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table(name:"Usuario")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar(45)")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public string Nome { get; set; }

        [Column("email", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Column("senha", TypeName = "varchar(45)")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public int Senha { get; set; }

        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }  

        public Usuarios ConverterParaEntidade()
        {
            var novoUsuario = new Usuarios();

            novoUsuario.Id = this.Id;
            novoUsuario.Nome = this.Nome;
            novoUsuario.Email = this.Email;
            novoUsuario.ImovelId = this.ImovelId;

            return (novoUsuario);
        }
    }
}
