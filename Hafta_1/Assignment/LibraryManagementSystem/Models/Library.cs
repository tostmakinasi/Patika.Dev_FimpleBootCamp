using LibraryManagementSystem.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Library : ILibrary, IPrintable
    {
        private List<Member> _members {get; set;} = new List<Member>();
        private List<Book> _books { get; set; } = new List<Book>();
        private LendingPolicy _lendingPolicy;

        public Library(LendingPolicy lendingPolicy)
        {
            BookSeeds();
            MemberSeeds();
            _lendingPolicy = lendingPolicy;
        }

        private void BookSeeds()
        {
            _books.Add(new Book(1, "The Catcher in the Rye", "J.D. Salinger", 1951));
            _books.Add(new Book(2, "To Kill a Mockingbird", "Harper Lee", 1960));
            _books.Add(new Book(3, "1984", "George Orwell", 1949));
            _books.Add(new Book(4, "The Great Gatsby", "F. Scott Fitzgerald", 1925));
            _books.Add(new Book(5, "One Hundred Years of Solitude", "Gabriel García Márquez", 1967));
            _books.Add(new Book(6, "Brave New World", "Aldous Huxley", 1932));
            _books.Add(new Book(7, "The Lord of the Rings", "J.R.R. Tolkien", 1954));
            _books.Add(new Book(8, "Pride and Prejudice", "Jane Austen", 1813));
            _books.Add(new Book(9, "The Hobbit", "J.R.R. Tolkien", 1937));
            _books.Add(new Book(10, "Crime and Punishment", "Fyodor Dostoevsky", 1866));
        }

        private void MemberSeeds()
        {
            _members.Add(new Member(1) { FirstName = "Kubilay", LastName = "Cem" });
            _members.Add(new Member(2) { FirstName = "Arya", LastName = "Kılıç" });
            _members.Add(new Member(3) { FirstName = "Bıdık", LastName = "Sarı" });
        }


        // Kitap ekleme işlemi
        private void AddBook(Book book)
        {
            _books.Add(book);
            
        }

        public void AddBook(string title, string author, int publicationYear)
        {
            int bookId = GetNextBookId();
            Book newBook = new Book(bookId, title, author, publicationYear);
            AddBook(newBook);
            Console.WriteLine($"'{newBook.Title}' kitabı kütüphaneye eklendi. Kitap ID: {bookId}");
        }

        // Kitap silme işlemi
        private void RemoveBook(Book book)
        {
            _books.Remove(book);
            Console.WriteLine($"'{book.Title}' kitabı kütüphaneden kaldırıldı.");
        }

        public void RemoveBook(int bookId)
        {
            var book = _books.Find(x=> x.BookId == bookId);
            if(book != null)
            {
                _books.Remove(book);
                Console.WriteLine($"'{book.Title}' kitabı kütüphaneden kaldırıldı.");
            }
            else
                Console.WriteLine($"'Id {bookId} olan kitap kütüphanede bulunamadı.");
        }

        // Üye ekleme işlemi
        private void AddMember(Member member)
        {
            _members.Add(member);
            Console.WriteLine($"{member.FirstName} {member.LastName} isimli üye kütüphaneye eklendi.");
        }

        public void AddMember(string firsName,string lastName)
        {
            _members.Add(new Member(GetNextMemberId(), firsName, lastName));
        }
        // Üye silme işlemi
        private void RemoveMember(Member member)
        {
            _members.Remove(member);
            Console.WriteLine($"{member.FirstName} {member.LastName} isimli üye kütüphaneden çıkarıldı.");
        }

        public void RemoveMember(int memberId)
        {
            var member = _members.Find(x => x.MemberId == memberId);
            if (member != null)
            {
                _members.Remove(member);
                Console.WriteLine($"'{member.FirstName} {member.LastName}' isimli üye kütüphaneden kaldırıldı.");
            }
            else
            {
                Console.WriteLine($"'ID {memberId}' numaralı üye kütüphanede bulunamadı.");
            }
        }
        // Kitap ödünç verme işlemi
        private void LendBook(Member member, Book book)
        {
            member.BorrowBook(book);
            _books.Remove(book);
            _lendingPolicy.ApplyPolicy(member, book);
        }

        public void LendBook(int memberId, int bookId)
        {
            var member = _members.Find(x => x.MemberId == memberId);
            var book = _books.Find(x => x.BookId == bookId);
            if (member != null || book != null)
            {
                LendBook(member, book);
            }
            else
                Console.WriteLine("Girilen Kitap yada Kullanıcı bulunamamıştır.");
        }

        // Kitap iade etme işlemi
        private void ReturnBook(Member member, Book book)
        {
            member.ReturnBook(book);
            _books.Add(book);
            Console.WriteLine($"'{book.Title}' kitabı {member.FirstName} {member.LastName}'den alındı.");
        }

        public void ReturnBook(int memberId, int bookId)
        {
            var member = _members.Find(x => x.MemberId == memberId);
            var book = _books.Find(x => x.BookId == bookId);
            if (member != null || book != null)
            {
                ReturnBook(member, book);
            }
            else
                Console.WriteLine("Girilen Kitap yada Kullanıcı bulunamamıştır.");
        }

        // Kütüphane bilgilerini yazdırma işlemi
        public void Print()
        {
            Console.WriteLine("\n--- KÜTÜPHANE BİLGİLERİ ---\n");

            Console.WriteLine("Kitaplar:");
            foreach (var book in _books)
            {
                book.Print();
                Console.WriteLine();
            }

            Console.WriteLine("--------------------------------\nÜyeler:");
            foreach (var member in _members)
            {
                member.Print();
                Console.WriteLine();
            }
            Console.WriteLine("******************************************");
        }

        //Yeni Eklenecek Kitap Id oluştur
        private int GetNextBookId()
        {
            var book = _books.OrderByDescending(x=> x.BookId).First();

            if(book != null)
                return book.BookId + 1;

            return 1;
        }

        //Yeni Eklenecek Kullanıcı Id oluştur
        private int GetNextMemberId()
        {
            var member = _members.OrderByDescending(x => x.MemberId).First();

            if (member != null)
                return member.MemberId + 1;

            return 1;
        }

        //Kütüğhanedeki Kitapları Listele
        public void ListBooks()
        {
            Console.WriteLine("Kitaplar:");
            foreach (var book in _books)
            {
                book.Print();
                Console.WriteLine();
            }
            Console.WriteLine("******************************************");
        }

        //Kayıtlı Kullanıcıları Listele
        public void ListMembers()
        {
            Console.WriteLine("Kullanıcılar:");
            foreach (var member in _members)
            {
                member.Print();
                Console.WriteLine();
            }
            Console.WriteLine("******************************************");
        }

        //Kullanıcının Ödünç Aldığı Kitapları Listele
        public void ListBorrowedBooks(int memberId)
        {
            var member = _members.Find(x => x.MemberId == memberId);
            if(member != null)
            {
                member.Print();
            }
            else 
                Console.WriteLine($"{memberId} Kullanıcı bulunamadı.");
        }
    }
}
