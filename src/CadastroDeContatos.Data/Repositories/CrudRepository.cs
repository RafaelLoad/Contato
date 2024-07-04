using CadastroDeContatos.Domain.Entities;
using CadastroDeContatos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeContatos.Data.Repositories
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public CrudRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public int Cadastrar(TEntity entidade)
        {
            _dbSet.Add(entidade);
            _dbContext.SaveChanges();
            return entidade.Id;
        }

        public TEntity Atualizar(TEntity entidade)
        {
            _dbSet.Update(entidade);
            _dbContext.SaveChanges();
            return entidade;
        }

        public TEntity Consultar(int id)
        => _dbSet.FirstOrDefault(x => x.Id == id);

        public void Deletar(int id)
        {
            _dbSet.Remove(Consultar(id));
            _dbContext.SaveChanges();
        }
    }
}
