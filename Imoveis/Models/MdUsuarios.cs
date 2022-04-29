using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table(name:"Usuario")]
    public class MdUsuarios
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
        public string Senha { get; set; }

        [Column("nivel", TypeName = "int")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public int Nivel { get; set; }

        public List<MdImoveis> Imoveis { get; set; }

        public MdUsuarios ConverterParaEntidade()
        {
            var novoUsuario = new MdUsuarios();

            novoUsuario.Id = this.Id;
            novoUsuario.Nome = this.Nome;
            novoUsuario.Email = this.Email;

            return (novoUsuario);
        }
    }
}
