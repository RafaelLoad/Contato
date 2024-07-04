using CadastroDeContatos.Application.Services;
using CadastroDeContatos.Domain.Entities;
using CadastroDeContatos.Domain.Interfaces;
using Moq;

namespace ContatoTeste.Testes
{
    public class ContatoServiceTestes
    {
        [Fact(DisplayName = "Should return success when registration is valid.")]
        public async void ShouldReturnSucessWhenRegistrationIsValid()
        {
            var mockContatoRepository = new Mock<IContatoRepository>();
            var mockDDDRepository = new Mock<IDddRepository>();

            //Arrange
            var validRegistration = new Contato { Nome = "Rafael", DDD = 11, Email = "Teste@hotmail.com", Telefone = 912345678 };
            var contatoService = new ContatoService(mockContatoRepository.Object, mockDDDRepository.Object);

            //Act
            contatoService.Cadastrar(validRegistration);

            //Assert
            mockContatoRepository.Verify(repo => repo.Cadastrar(It.Is<Contato>(c => c == validRegistration)), Times.Once);
        }

        [Fact(DisplayName = "Should return entity when update is valid")]
        public async void ShouldReturnEntityWhenUpdateIsValid()
        {
            var mockContatoRepository = new Mock<IContatoRepository>();
            var mockDDDRepository = new Mock<IDddRepository>();

            //Arrange
            var invalidRegistration = new Contato { Id = 1, Nome = "Rafael", DDD = 11, Email = "Teste@hotmail.com", Telefone = 912345678 };
            var contatoService = new ContatoService(mockContatoRepository.Object, mockDDDRepository.Object);


            //Act
            var result = contatoService.Atualizar(invalidRegistration);

            //Assert
            mockContatoRepository.Verify(repo => repo.Atualizar(It.Is<Contato>(c => c == invalidRegistration)), Times.Once);
        }
    }
}