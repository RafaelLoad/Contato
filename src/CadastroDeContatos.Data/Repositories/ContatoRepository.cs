using CadastroDeContatos.Domain.Entities;
using CadastroDeContatos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeContatos.Data.Repositories
{
    public class ContatoRepository : CrudRepository<Contato>, IContatoRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Contato> _contato;

        public ContatoRepository(DbContext context) : base(context)
        {
            _context = context;
            _contato = context.Set<Contato>();  
        }
    }
}
