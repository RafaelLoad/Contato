namespace CadastroDeContatos.Domain.Entities
{
    public class Contato : EntityBase
    {
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public int DDD { get; set; } 

    }
}
