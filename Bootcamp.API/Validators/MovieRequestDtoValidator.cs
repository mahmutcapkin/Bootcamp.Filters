using Bootcamp.API.DTOs;
using FluentValidation;

namespace Bootcamp.API.Validators
{
    public class MovieRequestDtoValidator:AbstractValidator<MovieRequestDto>
    {
        public MovieRequestDtoValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("Name alanı boş olamaz").NotEmpty().WithMessage("Name alanı boş olamaz");
            RuleFor(x => x.Income).NotNull().WithMessage("Income alanı boş olamaz");
            RuleFor(x => x.ReleaseDate).NotNull().WithMessage("ReleaseDate alanı boş olamaz");
            RuleFor(x => x.Rating).NotNull().WithMessage("Rating alanı boş olamaz");
        }
    }
}
