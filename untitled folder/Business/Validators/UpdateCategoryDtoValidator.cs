using FluentValidation;
using NLayerApp.Core.DTOs.CategoryDTOs;

namespace NLayerApp.Business.Validators
{
      public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
      {
            public UpdateCategoryDtoValidator()
            {
                  RuleFor(x => x.Name)
                      .NotEmpty().WithMessage("Name is required")
                      .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
            }
      }
}
