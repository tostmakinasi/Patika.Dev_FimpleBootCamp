using AutoMapper;
using BookStore.API.Application.BookOperations.Commands.CreateBook;
using BookStore.API.Application.BookOperations.Queries;
using BookStore.API.Application.BookOperations.Queries.GetBook;
using BookStore.API.DbOperations;
using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStore.API.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace BookStore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);

            return Ok(query.Execute());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;
                var book = query.Execute();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context, _mapper);
                command.Model = newBook;

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
            //return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, book);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book newBook)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book is null)
                return BadRequest();

            book.GenreId = newBook.GenreId != default ? newBook.GenreId : book.GenreId;
            book.Title = newBook.Title != default ? newBook.Title : book.Title;

            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book is null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
