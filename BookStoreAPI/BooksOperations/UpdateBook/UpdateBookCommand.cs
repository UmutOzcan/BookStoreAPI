﻿using WebApi.DBOperations;

namespace WebApi.BooksOperations.UpdateBook;

public class UpdateBookCommand
{
    private readonly BookStoreDbContext _dbContext;

    public int BookId { get; set; }
    public UpdateBookModel Model { get; set; }
    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId) ?? throw new InvalidOperationException("Güncellenecek kitap bulunamadı.");
        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        book.Title = Model.Title != default ? Model.Title : book.Title;
        book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
        _dbContext.SaveChanges();
    }
}

public class UpdateBookModel
{
    public required string Title { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }

}
