using FluentValidation;
namespace WebApi.BooksOperations.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Model.GenreId).GreaterThan(0);
        RuleFor(command => command.Model.PageCount).GreaterThan(0);
        RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date); // Bugünden küçük olamaz
        RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
    }
}