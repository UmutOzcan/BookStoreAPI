using WebApi.DBOperations;

namespace WebApi.BooksOperations.PatchBook;

public class PatchBookCommand
{
    private readonly BookStoreDbContext _dbContext;
    public int BookId { get; set; }
    public PatchBookModel Model { get; set; }
    public PatchBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId) ?? throw new InvalidOperationException("Güncellenecek kitap bulunamadı.");

        // eger güncelleme degerleri null degilse o alanlari guncelle
        if (Model.Title != null)
            book.Title = Model.Title;

        if (Model.GenreId != default)
            book.GenreId = Model.GenreId;

        if (Model.PageCount != default)
            book.PageCount = Model.PageCount;

        if (Model.PublishDate != default)
            book.PublishDate = Model.PublishDate;

        _dbContext.SaveChanges();
    }
}

public class PatchBookModel
{
    public required string Title { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}
