using FluentValidation;

namespace BookStore.BookOperations.UpdateBooks
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=>command.BookID).NotEmpty().GreaterThan(0);
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }

    }
}
