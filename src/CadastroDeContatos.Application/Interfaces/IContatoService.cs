using CadastroDeContatos.Domain.Entities;

namespace CadastroDeContatos.Application.Interfaces
{
    public interface IContatoService
    {
        Task<IEnumerable<Ddd>> Consultar(int ddd);
        Task<Contato> Atualizar(Contato contato);
        Task Cadastrar(Contato contato);
        Task Deletar(int id);
    }
}
