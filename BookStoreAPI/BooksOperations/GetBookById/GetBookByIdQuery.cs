using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.BooksOperations.GetById;

public class GetBookByIdQuery
{
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int BookId { get; set; }

    public GetBookByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookViewModel Handle()
    {
        var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault() ?? throw new InvalidOperationException("Kitap bulunamadı.");
        BookViewModel vm = _mapper.Map<BookViewModel>(book);
        return vm;
    }
}

public class BookViewModel
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int PageCount { get; set; }
    public required string PublishDate { get; set; }
}