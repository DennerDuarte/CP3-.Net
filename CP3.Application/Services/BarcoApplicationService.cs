using CP3.Application.Dtos;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;

namespace CP3.Application.Services
{
    public class BarcoApplicationService : IBarcoApplicationService
    {
        private readonly IBarcoRepository _repository;

        public BarcoApplicationService(IBarcoRepository repository)
        {
            _repository = repository;
        }

        public BarcoEntity AdicionarBarco(IBarcoDto entity)
        {
            return _repository.Adicionar(entity.ToEntity());
        }

        public BarcoEntity EditarBarco(int id, IBarcoDto entity)
        {
            return _repository.Editar(id, entity.ToEntity());
        }

        public BarcoEntity ObterBarcoPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<BarcoEntity> ObterTodosBarcos()
        {
            return _repository.ObterTodos();
        }

        public BarcoEntity RemoverBarco(int id)
        {
            return _repository.Remover(id);
        }
    }
}
