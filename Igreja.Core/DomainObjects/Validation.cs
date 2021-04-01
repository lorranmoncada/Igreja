using FluentValidation.Results;

namespace Igreja.Core.DomainObjects
{
    public abstract class Validation
    {
        protected ValidationResult ValidationResult { get; set; }

        public abstract bool EhValido();
    }
}
