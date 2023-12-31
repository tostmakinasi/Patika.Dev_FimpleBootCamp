using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Onur",
                        LastName = "Koca",
                        DateOfBirth = new DateTime(1996, 01, 01)

                    },
                    new Author
                    {
                        FirstName = "Mehmet",
                        LastName = "Kozanoğlu",
                        DateOfBirth = new DateTime(1996, 06, 12)
                    },
                    new Author
                    {
                        FirstName = "Mali",
                        LastName = "Zorba",
                        DateOfBirth = new DateTime(1996, 03, 24)
                    }
                );
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"


                    },
                    new Genre
                    {
                        Name = "Science Fiction"


                    },
                    new Genre
                    {
                        Name = "Ramance "


                    }
                );
                context.Books.AddRange(
                    new Book
                    {

                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                        new Book
                        {

                            Title = "Herland",
                            GenreId = 1,
                            PageCount = 250,
                            PublishDate = new DateTime(2010, 05, 23)
                        },
                        new Book
                        {

                            Title = "Dune",
                            GenreId = 2,
                            PageCount = 540,
                            PublishDate = new DateTime(2001, 12, 21)
                        }
                );

                context.SaveChanges();
            }
        }
    }
}
