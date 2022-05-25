using Microsoft.AspNetCore.Mvc;

namespace Imoveis.Models
{
    public class AgruparModels
    {
        [BindProperty]
        public MdImoveis oMdImoveis { get; set; }
        [BindProperty]
        public IEnumerable<MdImagens> oMdImagens { get; set; }
    }
}
