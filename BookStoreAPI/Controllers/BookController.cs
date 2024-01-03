using AutoMapper;
using BookStoreAPI.BooksOperations.DeleteBook;
using BookStoreAPI.BooksOperations.GetBookById;
using BookStoreAPI.BooksOperations.UpdateBook;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.BooksOperations.CreateBook;
using WebApi.BooksOperations.DeleteBook;
using WebApi.BooksOperations.GetBooks;
using WebApi.BooksOperations.GetById;
using WebApi.BooksOperations.PatchBook;
using WebApi.BooksOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        // context ile verilere eristik
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookViewModel result;

            GetBookByIdQuery query = new(_context, _mapper)
            {
                BookId = id
            };
            GetBookByIdQueryValidator validator = new();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new(_context, _mapper);

            command.Model = newBook;
            CreateBookCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {

            UpdateBookCommand command = new(_context)
            {
                BookId = id,
                Model = updatedBook
            };
            UpdateBookCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            DeleteBookCommand command = new(_context)
            {
                BookId = id
            };
            DeleteBookCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();


            return Ok();
        }

        // put gibi ama sadece tek bir prop u degistirir
        [HttpPatch("{id}")]
        public IActionResult PatchBook(int id, [FromBody] PatchBookModel patchedBook)
        {

            PatchBookCommand command = new(_context)
            {
                BookId = id,
                Model = patchedBook
            };
            command.Handle();


            return Ok();
        }

    }
}