using AutoMapper;
using WebApi.BooksOperations.CreateBook;
using WebApi.BooksOperations.GetBooks;
using WebApi.BooksOperations.GetById;
using WebApi.BooksOperations.PatchBook;
using WebApi.BooksOperations.UpdateBook;
using WebApi.Entities;

namespace WebApi.Common;

public class MapProfile : Profile
{

    public MapProfile()
    {
        // POST
        CreateMap<CreateBookModel, Book>().ReverseMap();
        // GET By ID
        CreateMap<BookViewModel, Book>().ReverseMap().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        // GET All
        CreateMap<BooksViewModel, Book>().ReverseMap().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
    }
}
