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
        public string Name { get; set; }

        public DateTime Data_Nascimento { get; set; }

        [NotMapped]
        public DateTime Idade { get; set; }
    }
}
