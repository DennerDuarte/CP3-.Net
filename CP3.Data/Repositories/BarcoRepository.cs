using CP3.Data.AppData;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;

namespace CP3.Data.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public BarcoEntity? Adicionar(BarcoEntity entity)
        {
            _context.Barco.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public BarcoEntity? Editar(int id, BarcoEntity entity)
        {
            var barco = _context.Barco.Find(id);
            if (barco != null)
            {
                barco.Modelo = entity.Modelo;
                barco.Nome = entity.Nome;
                barco.Ano = entity.Ano;
                barco.Tamanho = entity.Tamanho;
                _context.Barco.Update(barco);
                _context.SaveChanges();
            }
            return entity;
            
        }

        public BarcoEntity? ObterPorId(int id)
        {
            return _context.Barco.Find(id);
        }

        public IEnumerable<BarcoEntity>? ObterTodos()
        {
            return _context.Barco.ToList();
        }

        public BarcoEntity? Remover(int id)
        {
            var barco = _context.Barco.Find(id);
            if (barco != null)
            {
                _context.Barco.Remove(barco);
                _context.SaveChanges();
            }
            return barco;
        }
    }
}
