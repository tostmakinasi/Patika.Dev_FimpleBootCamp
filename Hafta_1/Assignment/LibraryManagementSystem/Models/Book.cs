using LibraryManagementSystem.Abstraction;
using LibraryManagementSystem.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book : WrittenWork, IPrintable
    {
        public Book(int id, string title, string author, int publicationYear) : base(id, title, author, publicationYear)
        {
        }

        public Book(int id) : base(id)
        {
            
        }

        public int BookId { 
            get {
                return _Id; 
            } 
        }
        public string Title { get { return _title; } set { _title = value.ToTitleCase(); } }
        public string Author { get { return _author; } set { _author = value.ToTitleCase(); } }
        public int PublicationYear { get { return _publicationYear; } set { _publicationYear = value; } }

        public void Print()
        {
            Console.WriteLine($"Book ID: {BookId}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Publication Year: {PublicationYear}");
        }
    }
}
