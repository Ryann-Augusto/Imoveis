using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table(name:"Usuario")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45)] [Required]
        public string Nome { get; set; }

        public DateTime Data_Nascimento { get; set; }

        [NotMapped]
        public DateTime Idade { get; set; }


        public Usuarios ConverterParaEntidade()
        {
            var novoUsuario = new Usuarios();

            novoUsuario.Id = this.Id;
            novoUsuario.Nome = this.Nome;
            novoUsuario.Data_Nascimento = this.Data_Nascimento;
            novoUsuario.Idade = DateTime.Today;

            return (novoUsuario);
        }
    }
}
