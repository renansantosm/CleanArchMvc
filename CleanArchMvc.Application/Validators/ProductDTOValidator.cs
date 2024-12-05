using CleanArchMvc.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Validators;

public class ProductDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductDTOValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid ID value");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Invalid name. Name is required.");
        RuleFor(x => x.Name).Length(3, 100).WithMessage("Invalid name,too short, minimum 3 characters.");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(x => x.Description).Length(5, 200).WithMessage("Description must be between 5 and 200 characters.");

        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock is required");
        RuleFor(x => x.Stock).InclusiveBetween(1, 9999).WithMessage("Stock must be between 1 and 9999");

        RuleFor(x => x.Image).MaximumLength(250).WithMessage("Image cant langer than 250 characters");
    }
}
