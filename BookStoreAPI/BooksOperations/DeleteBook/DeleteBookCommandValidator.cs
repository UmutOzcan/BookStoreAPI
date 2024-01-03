using FluentValidation;
using WebApi.BooksOperations.DeleteBook;
namespace BookStoreAPI.BooksOperations.DeleteBook;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.BookId).GreaterThan(0);
    }
}
