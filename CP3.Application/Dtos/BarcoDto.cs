using CP3.Domain.Entities;
using CP3.Domain.Interfaces.Dtos;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public double Tamanho { get; set; }

        public void Validate()
        {
            var validateResult = new BarcoDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));

        }
    }

    internal class BarcoDtoValidation : AbstractValidator<BarcoDto>
    {
        public BarcoDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage($"o Campo {nameof(BarcoDto.Nome)} deve ter no mínimo 5 caracteres.")
                .NotEmpty().WithMessage($"o Campo {nameof(BarcoDto.Nome)} não pode ser vazio.");

            RuleFor(x => x.Modelo)
                 .MinimumLength(5).WithMessage($"o Campo {nameof(BarcoDto.Modelo)} deve ter no mínimo 5 caracteres.")
                 .NotEmpty().WithMessage($"o Campo {nameof(BarcoDto.Modelo)} não pode ser vazio.");

            RuleFor(x => x.Ano)
                 .NotEmpty().WithMessage($"o Campo {nameof(BarcoDto.Ano)} não pode ser vazio.");

            RuleFor(x => x.Tamanho)
                 .NotEmpty().WithMessage($"o Campo {nameof(BarcoDto.Tamanho)} não pode ser vazio.");

        }
    }

    internal static class BarcoMapper
    {
        public static IBarcoDto ToDto(this BarcoEntity entity)
        {
            return new BarcoDto
            {
                Nome = entity.Nome,
                Tamanho = entity.Tamanho,
                Modelo = entity.Modelo,
                Ano = entity.Ano
            };
        }

        public static BarcoEntity ToEntity(this IBarcoDto dto)
        {

            return new BarcoEntity
            {
                Nome = dto.Nome,
                Tamanho = dto.Tamanho,
                Modelo = dto.Modelo,
                Ano = dto.Ano
            };
        }
    }

}
