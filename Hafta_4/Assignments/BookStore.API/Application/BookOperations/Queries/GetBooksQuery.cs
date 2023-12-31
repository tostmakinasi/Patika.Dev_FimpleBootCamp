using AutoMapper;
using BookStore.API.DbOperations;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Application.BookOperations.Queries;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<BooksViewModel> Execute()
    {
        var books = _dbContext.Books.Include(x=> x.Genre).ToList();

        var booksViewModel = _mapper.Map<List<BooksViewModel>>(books);

        return booksViewModel;
    }
}

public class BooksViewModel
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    public string Genre { get; set; }
}