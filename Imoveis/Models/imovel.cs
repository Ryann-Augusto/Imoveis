using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table("imovel")]
    public class imovel
    {
        [Key]
        public int ImovelId { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(200)]
        public string ImovelDsc{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column(TypeName= "decimal(18,2)")]
        public decimal ImovelVlr{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public int NumQrtImovel { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public int NumVagImovel { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(15)]
        public string TipImovel { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(100)]
        public string RuaImovel { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        public string BroImovel { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        public string CddImovel { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        public string UFImovel { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(8)]
        public string CEPImovel { get; set; }

    }
}
