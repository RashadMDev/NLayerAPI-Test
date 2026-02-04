using API.DTOs;
using FluentValidation;

namespace API.Validators
{
      public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
      {
            public CreateCategoryDtoValidator()
            {
                  RuleFor(x => x.Name)
                      .NotEmpty().WithMessage("Name is required")
                      .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

                  RuleFor(x => x.Description)
                      .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

                  RuleFor(x => x.Price)
                      .GreaterThan(0).WithMessage("Price must be greater than 0")
                      .LessThanOrEqualTo(999999.99m).WithMessage("Price cannot exceed 999,999.99");

                  RuleFor(x => x.Stock)
                      .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative");
            }
      }
}
