using FluentValidation;
using Kiosk.WebAPI.Dto;
using Kiosk.WebAPI.Persistance;
using System.Numerics;
using System.Security.Principal;

public class RegisterCreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    private readonly IProductRepository _uow;

    public RegisterCreateProductDtoValidator(IProductRepository products)
    {

        _uow = products;
         RuleFor(p => p.Name)
          .NotEmpty()
          .MinimumLength(2)
          .MaximumLength(20)
          .Must(_uow.CanBeUsed)
          .WithMessage("Please specify a unique product name with length between 2 and 20 characters");
        /* RuleFor(p => p.Name)
             .Length(2, 20)
             .WithMessage("Please specify a product name");*/
           
        RuleFor(p => p.UnitPrice)
            .GreaterThan((decimal)0.01)
            .WithMessage("Price must be greater than 0.01");



    }
}