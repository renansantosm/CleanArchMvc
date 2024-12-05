using CleanArchMvc.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Validators;

public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
{
    public CategoryDTOValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid ID value");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Invalid name. Name is required.");
        RuleFor(x => x.Name).Length(3, 100).WithMessage("Invalid name,too short, minimum 3 characters.");
    }
}
