using FluentValidation;
using WebApi.BooksOperations.GetById;

namespace BookStoreAPI.BooksOperations.GetBookById;

public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(query => query.BookId).GreaterThan(0);
    }
}
