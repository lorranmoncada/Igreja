using FluentValidation;
using FluentValidation.Results;
using Igreja.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Igreja.Domain.ViewModel
{
    public class CadastroFielViewModel : Validation
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NomeFiel { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public Guid IdIgreja { get; set; }
        public string Endereco { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new CadastroFielViewModelValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public override IList<ValidationFailure> Erros()
        {
            return ValidationResult.Errors;
        }
    }

    public class CadastroFielViewModelValidation : AbstractValidator<CadastroFielViewModel>
    {
        public CadastroFielViewModelValidation()
        {
            RuleFor(f => f.Cep).MaximumLength(8).MinimumLength(8);
            RuleFor(f => f.Login).MaximumLength(20).MinimumLength(8);
            RuleFor(f => f.Senha).MaximumLength(10).MinimumLength(8);
            RuleFor(f => f.Cpf).MinimumLength(11).MaximumLength(11);
            RuleFor(f => f.Telefone).MinimumLength(11).MaximumLength(11);
            RuleFor(f => f.IdIgreja).NotEmpty().WithMessage("Selecione a igreja");
            RuleFor(f => f.Email).NotEmpty().WithMessage("Email obrigatório").EmailAddress().WithMessage("Esse e-mail esta inválido");
            RuleFor(f => f.Endereco).NotEmpty().WithMessage("Preencha seu endereço");
        }
    }
}
