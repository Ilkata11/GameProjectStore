using FluentValidation;
using GameStore.Models;

namespace GameStore.API.Validations
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(g => g.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Title cannot be more than 100 characters.");

            RuleFor(g => g.Genre)
                .NotEmpty().WithMessage("Genre is required.")
                .MinimumLength(3).WithMessage("Genre must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Genre cannot be more than 50 characters.");

            RuleFor(g => g.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.")
                .LessThan(1000).WithMessage("Price must be less than 1000.");
        }
    }
}
