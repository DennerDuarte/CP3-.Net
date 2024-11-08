using CP3.Data.AppData;
using CP3.Data.Repositories;
using CP3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CP3.Tests
{
    public class BarcoRepositoryTests
    {
        private readonly ApplicationContext _context;
        private readonly BarcoRepository _repository;
        private readonly DbContextOptions<ApplicationContext> _options;

        public BarcoRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;
            _context = new ApplicationContext(_options);
            _repository = new BarcoRepository(_context);
        }

        [Fact]
        public void Adicionar_DeveAdicionarBarcoEChamarSaveChanges()
        {
            var barco = new BarcoEntity { Nome = "Barco Teste" };

            var resultado = _repository.Adicionar(barco);

            var barcoDb = _context.Barco.FirstOrDefault(x => x.Id == resultado.Id);
            Assert.NotNull(barcoDb);
            Assert.Equal(barco.Nome, barcoDb.Nome);
        }

        [Fact]
        public void Editar_DeveAtualizarBarcoQuandoExistir()
        {
            var barco = new BarcoEntity { Id = 3, Nome = "Barco Antigo" };
            _context.Barco.Add(barco);
            _context.SaveChanges();

            barco.Nome = "barco novo";
            _repository.Editar(1, barco);

            var barcoDb = _context.Barco.FirstOrDefault(x => x.Id == barco.Id);
            Assert.NotNull(barcoDb);
            Assert.Equal("barco novo", barcoDb.Nome);           
        }

        [Fact]
        public void ObterPorId_DeveRetornarBarcoQuandoExistir()
        {
            var barco = new BarcoEntity { Id = 5, Nome = "Barco Teste" };
            _context.Barco.Add(barco);
            _context.SaveChanges();

            var resultado = _repository.ObterPorId(barco.Id);

            Assert.NotNull(resultado);
            Assert.Equal("Barco Teste", resultado.Nome);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeBarcos()
        {
            var barco = new BarcoEntity { Id = 1, Nome = "Barco Teste" };
            var barco2 = new BarcoEntity { Id = 2, Nome = "Barco Teste2" };
            _context.Barco.Add(barco);
            _context.Barco.Add(barco2);
            _context.SaveChanges();

            var resultado = _repository.ObterTodos();

            Assert.Equal(2, resultado.Count());
        }

        [Fact]
        public void Remover_DeveRemoverBarcoEChamarSaveChanges()
        {
            var barco = new BarcoEntity { Id = 1, Nome = "Barco Teste" };
            _context.Barco.Add(barco);
            _context.SaveChanges();

            var resultado = _repository.Remover(barco.Id);

            var barcoDb = _context.Barco.FirstOrDefault(x => x.Id == barco.Id);
            Assert.NotNull(resultado);
            Assert.Equal(barco, resultado);
           
        }
    }
}
