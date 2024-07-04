using CadastroDeContatos.Domain.Entities;
using FluentValidation;

namespace CadastroDeContatos.Domain.Validator
{
    public  class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            var dddsValidos = new List<int>()
            {
                11, 12, 13, 14, 15, 16, 17, 18, 19,
                21, 22, 24, 27, 28,
                31, 32, 33, 34, 35, 37, 38,
                41, 42, 43, 44, 45, 46,
                47, 48, 49,
                51, 53, 54, 55,
                61, 62, 63, 64, 65, 66, 67,
                68, 69,
                71, 73, 74, 75, 77,
                79, 81, 82, 83, 84, 85, 86, 87, 88, 89,
                91, 92, 93, 94, 95, 96, 97, 98, 99
            };


            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotEqual("string")
                .MaximumLength(255)
                .WithMessage("Nome não pode ser nulo");

            RuleFor(x => x.Telefone)
            .NotNull().WithMessage("Telefone não pode ser nulo")
            .Must(x => x >= 100000000 && x <= 999999999).WithMessage("Telefone deve ter exatamente 9 dígitos");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email não pode ser nulo")
                .EmailAddress()
                .WithMessage("Email deve ser um endereço de email válido");

            RuleFor(x => x.DDD)
           .Must(ddd => dddsValidos.Contains(ddd))
           .WithMessage("DDD inválido.");
        }
    }
}
