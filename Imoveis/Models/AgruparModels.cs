namespace Imoveis.Models
{
    public class AgruparModels
    {
        public MdImoveis oMdImoveis { get; set; }
        public MdEndereco oMdEndeco { get; set; }
        public IEnumerable<MdImagens> oMdImagens { get; set; }
    }
}
