using CadastroDeContatos.Application.Services;
using CadastroDeContatos.Domain.Entities;
using CadastroDeContatos.Domain.Interfaces;
using Moq;
using NUnit.Framework;

public class ContatoServiceTests
{
    private Mock<IContatoRepository> _mockContatoRepository;
    private Mock<IDddRepository> _mockDDDRepository;
    private ContatoService _contatoService;

    [SetUp]
    public void Setup()
    {
        _mockContatoRepository = new Mock<IContatoRepository>();
        _mockDDDRepository = new Mock<IDddRepository>();
        _contatoService = new ContatoService(_mockContatoRepository.Object, _mockDDDRepository.Object);
    }

    [Test]
    public void Cadastrar_ShouldReturnId_WhenCadastroIsValid()
    {
        // Arrange
        var validRegistration = new Contato { Nome = "Rafael", DDD = 11, Email = "Teste@hotmail.com", Telefone = 912345678 };
        var expectedId = 1; 

        _mockContatoRepository.Setup(repo => repo.Cadastrar(It.IsAny<Contato>())).Callback((Contato contato) =>
        {
            contato.Id = expectedId;
        });

        // Act
        var result = _contatoService.Cadastrar(validRegistration);

        // Assert
        Assert.That(result.Id, Is.EqualTo(expectedId)); 
        _mockContatoRepository.Verify(repo => repo.Cadastrar(It.Is<Contato>(c => c == validRegistration)), Times.Once);
    }

    [Test]
    public void Cadastrar_ShouldReturnNull_WhenCadastroIsNotValid()
    {
        // Arrange
        var invalidRegistration = new Contato { Nome = "Rafael", DDD = 0, Email = "Teste@hotmail.com", Telefone = 912345678 };

        // Act
        var result = _contatoService.Cadastrar(invalidRegistration);

        // Assert
        _mockContatoRepository.Verify(repo => repo.Cadastrar(It.IsAny<Contato>()), Times.Never);
    }
}