namespace CadastroDeContatos.Domain.Entities
{
    public class Ddd : EntityBase
    {
        public int ContatoId { get; set; }  
        public string Regiao { get; set; }
        public Contato Contato { get; set; }
    }
}
