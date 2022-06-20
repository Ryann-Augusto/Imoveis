using System.ComponentModel.DataAnnotations;

namespace Imoveis.Models
{
    public class DadosLogin
    {
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name= "Lembrar de mim")]
        public string Lembrar { get; set; }
    }
}
