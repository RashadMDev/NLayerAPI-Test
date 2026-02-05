
using FluentValidation;
using NLayerApp.Core.DTOs.CategoryDTOs;

namespace NLayerApp.Business.Validators
{
      public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
      {
            public CreateCategoryDtoValidator()
            {
                  RuleFor(x => x.Name)
                      .NotEmpty().WithMessage("Name is required")
                      .MaximumLength(20).WithMessage("Name cannot exceed 20 characters");
            }
      }
}
