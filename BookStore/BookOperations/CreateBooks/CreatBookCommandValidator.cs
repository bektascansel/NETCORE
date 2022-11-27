using FluentValidation;

namespace BookStore.BookOperations.CreateBooks.CreateBookCommandValidator{

  public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand> {

    public CreateBookCommandValidator(){

        RuleFor(command=>command.Model.GenreId).GreaterThan(0);
        RuleFor(command=>command.Model.PageCount).GreaterThan(0);
        RuleFor(command=>command.Model.Title).NotEmpty().MinimumLength(4);

    }
    
  }






}