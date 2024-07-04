using CadastroDeContatos.Application.Interfaces;
using CadastroDeContatos.Domain.Entities;
using CadastroDeContatos.Domain.Interfaces;

namespace CadastroDeContatos.Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IDddRepository _dddRepository;

        public ContatoService(IContatoRepository contatoRepository, IDddRepository dddRepository)
        {
            _contatoRepository = contatoRepository;
            _dddRepository = dddRepository;
        }

        public async Task<IEnumerable<Ddd>> Consultar(int ddd)
            => _dddRepository.ConsultarContatosPeloDDD(ddd);
     
        public async Task<Contato> Atualizar(Contato contato)
            => _contatoRepository.Atualizar(contato);

        public async Task Cadastrar(Contato contato)
        {
             var contatoId = _contatoRepository.Cadastrar(contato);

            var ddd = new Ddd
            {
                Contato = contato,
                ContatoId = contatoId,
                Regiao = ObterRegiaoPorDDD(contato.DDD)
            };

            _dddRepository.Cadastrar(ddd);
        }
 
        public async Task Deletar(int id)
            => _contatoRepository.Deletar(id);

        private string ObterRegiaoPorDDD(int ddd)
        {
            switch (ddd)
            {
                case 11: return "São Paulo (capital e região metropolitana)";
                case 12: return "Vale do Paraíba e litoral norte de São Paulo";
                case 13: return "Baixada Santista e litoral sul de São Paulo";
                case 14: return "Centro-oeste do estado de São Paulo";
                case 15: return "Região de Sorocaba (SP)";
                case 16: return "Região de Ribeirão Preto (SP)";
                case 17: return "Região de São José do Rio Preto (SP)";
                case 18: return "Oeste do estado de São Paulo";
                case 19: return "Região de Campinas (SP)";
                case 21: return "Rio de Janeiro (capital e região metropolitana)";
                case 22: return "Norte e noroeste do estado do Rio de Janeiro";
                case 24: return "Região serrana e Vale do Paraíba do estado do Rio de Janeiro";
                case 27: return "Espírito Santo (norte e Grande Vitória)";
                case 28: return "Espírito Santo (sul)";
                case 31: return "Belo Horizonte (MG)";
                case 32: return "Zona da Mata e Campos das Vertentes (MG)";
                case 33: return "Vale do Rio Doce e Vale do Mucuri (MG)";
                case 34: return "Triângulo Mineiro e Alto Paranaíba (MG)";
                case 35: return "Sul e sudoeste de Minas Gerais";
                case 37: return "Centro-oeste de Minas Gerais";
                case 38: return "Norte de Minas Gerais";
                case 41: return "Curitiba e região metropolitana (PR)";
                case 42: return "Centro-sul do Paraná";
                case 43: return "Norte do Paraná";
                case 44: return "Noroeste do Paraná";
                case 45: return "Oeste do Paraná";
                case 46: return "Sudoeste do Paraná";
                case 47: return "Norte de Santa Catarina";
                case 48: return "Grande Florianópolis, sul e parte do Vale do Itajaí (SC)";
                case 49: return "Oeste de Santa Catarina";
                case 51: return "Porto Alegre e região metropolitana (RS)";
                case 53: return "Sul do Rio Grande do Sul";
                case 54: return "Nordeste do Rio Grande do Sul";
                case 55: return "Oeste do Rio Grande do Sul";
                case 61: return "Distrito Federal e entorno";
                case 62: return "Região de Goiânia (GO)";
                case 63: return "Tocantins";
                case 64: return "Sudoeste de Goiás";
                case 65: return "Região de Cuiabá (MT)";
                case 66: return "Interior do Mato Grosso";
                case 67: return "Mato Grosso do Sul";
                case 68: return "Acre";
                case 69: return "Rondônia";
                case 71: return "Salvador e região metropolitana (BA)";
                case 73: return "Sul da Bahia";
                case 74: return "Centro-norte da Bahia";
                case 75: return "Norte e nordeste da Bahia";
                case 77: return "Oeste da Bahia";
                case 79: return "Sergipe";
                case 81: return "Região metropolitana de Recife (PE)";
                case 82: return "Alagoas";
                case 83: return "Paraíba";
                case 84: return "Rio Grande do Norte";
                case 85: return "Região metropolitana de Fortaleza (CE)";
                case 86: return "Centro-norte do Piauí";
                case 87: return "Interior de Pernambuco";
                case 88: return "Interior do Ceará";
                case 89: return "Sul do Piauí";
                case 91: return "Região metropolitana de Belém (PA)";
                case 92: return "Região metropolitana de Manaus (AM)";
                case 93: return "Oeste do Pará";
                case 94: return "Sudeste do Pará";
                case 95: return "Roraima";
                case 96: return "Amapá";
                case 97: return "Oeste do Amazonas";
                case 98: return "Região metropolitana de São Luís (MA)";
                case 99: return "Interior do Maranhão";
                default: return "DDD inválido";
            }
        }
    }
}
