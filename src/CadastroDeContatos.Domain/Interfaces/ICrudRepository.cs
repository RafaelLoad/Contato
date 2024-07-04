namespace CadastroDeContatos.Domain.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        TEntity Consultar(int id);
        TEntity Atualizar(TEntity entidade);
        int Cadastrar(TEntity entitdade);
        void Deletar(int id);
    }
}
