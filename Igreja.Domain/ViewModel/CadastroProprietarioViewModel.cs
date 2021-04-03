using FluentValidation;
using FluentValidation.Results;
using Igreja.Core.DomainObjects;
using Igreja.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Igreja.Domain.ViewModel
{
    public class CadastroProprietarioViewModel : Validation
    {
        // cadastro
        public string Login { get; set; }
        public string Senha { get; set; }
        //Proprietario
        public string NomeProprietario { get; set; }
        public string CpfProrpietario { get; set; }
        //categoria
        public Guid IdTipoCategoria { get; set; }
        //igreja
        public string NomeEnderecoIgreja { get; set; }
        public string CepIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public string CnpjIgreja { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarProprietario().Validate(this);
            return ValidationResult.IsValid;
        }

        public override IList<ValidationFailure> Erros()
        {
            return ValidationResult.Errors;
        }

        public class CadastrarProprietario : AbstractValidator<CadastroProprietarioViewModel>
        {
            public CadastrarProprietario()
            {
                RuleFor(c => c.Login).Cascade(CascadeMode.Stop)
                    .Length(6, 50).WithMessage("O login deve possuir no mínimo 6 caracteres e no máximo 50");

                RuleFor(c => c.Senha).Cascade(CascadeMode.Stop)
                   .Length(6, 10).WithMessage("A senha deve possuir no mínimo 6 caracteres e no máximo 10");

                RuleFor(c => c.NomeProprietario).Cascade(CascadeMode.Stop)
                   .Length(3, 100).WithMessage("O nome do proprietário deve ter no mínimo de 3 á 100 letras");

                RuleFor(c => c.NomeIgreja).Cascade(CascadeMode.Stop)
                  .Length(3, 200).WithMessage("O nome da igreja deve ter no mínimo de 3 á 200 letras");

                RuleFor(c => c.CpfProrpietario).Must(CpfOuCnpj.IsCpf).WithMessage("Cpf inválido");

                RuleFor(c => c.CepIgreja).MinimumLength(8).MaximumLength(8);

                RuleFor(c => c.CnpjIgreja).Must(CpfOuCnpj.IsCnpj).WithMessage("Cnpj inválido");

            }
        }
    }
}
