using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.BooksOperations.GetBooks;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext; // sadece constructordan set edilsin istiyoruz
    private readonly IMapper _mapper;

    public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<BooksViewModel> Handle()
    {
        var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
        List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
        return vm;
    }
}

public class BooksViewModel
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int PageCount { get; set; }
    public required string PublishDate { get; set; }
}