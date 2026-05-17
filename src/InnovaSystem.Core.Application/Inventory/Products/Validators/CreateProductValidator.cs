using FluentValidation;
using InnovaSystem.Core.Application.Common.Validators;
using InnovaSystem.Core.Application.Inventory.Products.Commands;

namespace InnovaSystem.Core.Application.Inventory.Products.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Product)
                .SetValidator(new ProductValidator());
        }
    }
}
