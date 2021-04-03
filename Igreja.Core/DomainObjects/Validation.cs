using FluentValidation.Results;
using System.Collections.Generic;

namespace Igreja.Core.DomainObjects
{
    public abstract class Validation
    {
        protected ValidationResult ValidationResult { get; set; }

        public abstract bool EhValido();

        public abstract IList<ValidationFailure> Erros();
    }
}
