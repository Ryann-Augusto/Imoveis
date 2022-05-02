using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table(name:"usuario")]
    public class MdUsuarios
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar(45)")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(45, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("email", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "O campo {0} deve conter um endereço de E-mail válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Column("senha", TypeName = "varchar(45)")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(45, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        public string Senha { get; set; }

        [Column("nivel", TypeName = "int")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public int Nivel { get; set; }

        public List<MdImoveis> Imoveis { get; set; }


        // Validação p/ Campo CPF
        // [RegularExpression(@"[0-9]{11}$", ErrorMessage = "O campo {0} deve ser preenchido com um CPF.")]
    }
}
