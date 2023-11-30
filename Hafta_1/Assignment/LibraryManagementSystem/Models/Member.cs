using LibraryManagementSystem.Abstraction;
using LibraryManagementSystem.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Member : IPrintable
    {
        private int _memberID;
        private string _firstName;
        private string _lastName;
        private List<Book> _borrowedBooks;

        public int MemberId
        {
            get
            {
                return _memberID;
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value.ToTitleCase(); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value.ToTitleCase(); }
        }

        private List<Book> BorrowedBooks
        {
            get { return _borrowedBooks ?? (_borrowedBooks = new List<Book>()); }
            set { _borrowedBooks = value; }
        }

        public Member(int memberId)
        {
            _memberID = memberId;
        }
        public Member(int memberId, string firsName, string lastName)
        {
            _memberID = memberId;
            _firstName = firsName;
            _lastName = lastName;
        }

        // Kitap ödünç alma işlemi
        public void BorrowBook(Book book)
        {
            if (!BorrowedBooks.Contains(book))
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"{FirstName} {LastName}, '{book.Title}' kitabını ödünç aldı.");
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName}, '{book.Title}' kitabını zaten ödünç almış.");
            }
        }

        // Kitap iade etme işlemi
        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                BorrowedBooks.Remove(book);
                Console.WriteLine($"{FirstName} {LastName}, '{book.Title}' kitabını iade etti.");
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName}, '{book.Title}' kitabını ödünç almamış.");
            }
        }

        public void Print()
        {
            Console.WriteLine($"\tKullanıcı Bilgileri\nKullanıcı Adı: {FirstName} {LastName}\n\tÖdünç Aldığı Kitaplar:\n");

            foreach (var book in BorrowedBooks)
            {
                book.Print();
            }
        }


    }
}
