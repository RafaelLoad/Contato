using CadastroDeContatos.Domain.Entities;

namespace CadastroDeContatos.Domain.Interfaces
{
    public interface IDddRepository : ICrudRepository<Ddd>
    {
        IEnumerable<Ddd> ConsultarContatosPeloDDD(int ddd);
    }
}
