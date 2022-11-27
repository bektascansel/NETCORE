using FluentValidation;

namespace BookStore.BookOperations.DeleteBooks
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.bookID).GreaterThan(0);
        }
    }
    
}
