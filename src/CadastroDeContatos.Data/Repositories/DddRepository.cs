using CadastroDeContatos.Domain.Entities;
using CadastroDeContatos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeContatos.Data.Repositories
{
    public class DddRepository : CrudRepository<Ddd>, IDddRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Ddd> _ddd;

        public DddRepository(DbContext context) : base(context)
        {
            _context = context;
            _ddd = context.Set<Ddd>();  
        }

        public IEnumerable<Ddd> ConsultarContatosPeloDDD(int ddd)
        => _ddd.Where(x => x.Contato.DDD.Equals(ddd)).Include(x => x.Contato);   
    }
}
