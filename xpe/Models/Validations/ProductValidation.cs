using FluentValidation;

namespace xpe.Models.Validations;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .Length(2, 200)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .Length(2, 200)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Price)
            .GreaterThan(0).WithMessage("O valor deve ser maior que zero.")
            .LessThan(decimal.MaxValue).WithMessage($"O valor deve ser menor que {decimal.MaxValue}.");

        RuleFor(p => p.Sku)
            .MaximumLength(50)
            .WithMessage("O campo {PropertyName} deve ter no máximo {MaxLength} caracteres");
    }
}