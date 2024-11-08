using CP3.Application.Services;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;
using Moq;


namespace CP3.Tests
{
    public class BarcoApplicationServiceTests
    {
        private readonly Mock<IBarcoRepository> _repositoryMock;
        private readonly BarcoApplicationService _barcoService;

        public BarcoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IBarcoRepository>();
            _barcoService = new BarcoApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public void AdicionarBarco_DeveRetornarBarcoEntity_QuandoAdicionarComSucesso()
        {
            // Arrange
            var barcoDtoMock = new Mock<IBarcoDto>();
            barcoDtoMock.Setup(b => b.Nome).Returns("Veleiro");
            barcoDtoMock.Setup(b => b.Modelo).Returns("Oceanis 30.1");
            barcoDtoMock.Setup(b => b.Ano).Returns(2021);
            barcoDtoMock.Setup(b => b.Tamanho).Returns(30);

            var barcoEsperado = new BarcoEntity { Nome = "Veleiro", Modelo = "Oceanis 30.1", Ano = 2021, Tamanho = 30 };
            _repositoryMock.Setup(r => r.Adicionar(It.IsAny<BarcoEntity>())).Returns(barcoEsperado);

            // Act
            var resultado = _barcoService.AdicionarBarco(barcoDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(barcoEsperado.Nome, resultado.Nome);
            Assert.Equal(barcoEsperado.Modelo, resultado.Modelo);
            Assert.Equal(barcoEsperado.Ano, resultado.Ano);
            Assert.Equal(barcoEsperado.Tamanho, resultado.Tamanho);
        }

        [Fact]
        public void EditarBarco_DeveRetornarBarcoEntity_QuandoEditarComSucesso()
        {
            // Arrange
            var barcoDtoMock = new Mock<IBarcoDto>();
            barcoDtoMock.Setup(b => b.Nome).Returns("Catamarã");
            barcoDtoMock.Setup(b => b.Modelo).Returns("Lagoon 42");
            barcoDtoMock.Setup(b => b.Ano).Returns(2020);
            barcoDtoMock.Setup(b => b.Tamanho).Returns(42);

            var barcoEsperado = new BarcoEntity { Id = 1, Nome = "Catamarã", Modelo = "Lagoon 42", Ano = 2020, Tamanho = 42 };
            _repositoryMock.Setup(r => r.Editar(It.IsAny<int>(), It.IsAny<BarcoEntity>())).Returns(barcoEsperado);

            // Act
            var resultado = _barcoService.EditarBarco(1, barcoDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(barcoEsperado.Id, resultado.Id);
            Assert.Equal(barcoEsperado.Nome, resultado.Nome);
            Assert.Equal(barcoEsperado.Modelo, resultado.Modelo);
            Assert.Equal(barcoEsperado.Ano, resultado.Ano);
            Assert.Equal(barcoEsperado.Tamanho, resultado.Tamanho);
        }

        [Fact]
        public void ObterBarcoPorId_DeveRetornarBarcoEntity_QuandoBarcoExiste()
        {
            // Arrange
            var barcoEsperado = new BarcoEntity { Id = 1, Nome = "Iate", Modelo = "Sunseeker", Ano = 2018, Tamanho = 70 };
            _repositoryMock.Setup(r => r.ObterPorId(1)).Returns(barcoEsperado);

            // Act
            var resultado = _barcoService.ObterBarcoPorId(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(barcoEsperado.Id, resultado.Id);
            Assert.Equal(barcoEsperado.Nome, resultado.Nome);
            Assert.Equal(barcoEsperado.Modelo, resultado.Modelo);
            Assert.Equal(barcoEsperado.Ano, resultado.Ano);
            Assert.Equal(barcoEsperado.Tamanho, resultado.Tamanho);
        }

        [Fact]
        public void ObterTodosBarcos_DeveRetornarListaDeBarcos_QuandoExistiremBarcos()
        {
            // Arrange
            var barcosEsperados = new List<BarcoEntity>
            {
                new BarcoEntity { Id = 1, Nome = "Lancha", Modelo = "Phantom 300", Ano = 2015, Tamanho = 30 },
                new BarcoEntity { Id = 2, Nome = "Escuna", Modelo = "Escuna Classic", Ano = 2010, Tamanho = 50 }
            };
            _repositoryMock.Setup(r => r.ObterTodos()).Returns(barcosEsperados);

            // Act
            var resultado = _barcoService.ObterTodosBarcos();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal(barcosEsperados.First().Nome, resultado.First().Nome);
        }

        [Fact]
        public void RemoverBarco_DeveRetornarBarcoEntity_QuandoRemoverComSucesso()
        {
            // Arrange
            var barcoEsperado = new BarcoEntity { Id = 1, Nome = "Bote", Modelo = "Inflável", Ano = 2019, Tamanho = 10 };
            _repositoryMock.Setup(r => r.Remover(1)).Returns(barcoEsperado);

            // Act
            var resultado = _barcoService.RemoverBarco(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(barcoEsperado.Id, resultado.Id);
            Assert.Equal(barcoEsperado.Nome, resultado.Nome);
            Assert.Equal(barcoEsperado.Modelo, resultado.Modelo);
            Assert.Equal(barcoEsperado.Ano, resultado.Ano);
            Assert.Equal(barcoEsperado.Tamanho, resultado.Tamanho);
        }
    }
}
