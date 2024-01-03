using FluentValidation;
using WebApi.BooksOperations.UpdateBook;

namespace BookStoreAPI.BooksOperations.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.BookId).GreaterThan(0);
        RuleFor(command => command.Model.GenreId).GreaterThan(0);
        RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
    }
}
