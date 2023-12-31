using AutoMapper;
using BookStore.API.Application.BookOperations.Queries;
using BookStore.API.Application.BookOperations.Queries.GetBook;
using BookStore.API.Models;
using static BookStore.API.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace BookStore.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            //CreateMap<Genre, GenresViewModel>();
            //CreateMap<Genre, GenreDetailViewModel>();
            //CreateMap<Author, AuthorsViewModel>();
            //CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));
            //CreateMap<CreateAuthorModel, Author>();
            //CreateMap<CreateUserModel, User>();
        }
    }
}
