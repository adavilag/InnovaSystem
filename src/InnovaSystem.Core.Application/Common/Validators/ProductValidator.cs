using FluentValidation;
using InnovaSystem.Core.Domain.Entities.Inventory;

namespace InnovaSystem.Core.Application.Common.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Nombre del producto requerido")
                .MaximumLength(100);
        }
    }
}
