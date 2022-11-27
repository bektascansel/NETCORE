using FluentValidation;

namespace BookStore.BookOperations.GetBookDetails
{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).NotNull().GreaterThan(0);
        }

    }
}
