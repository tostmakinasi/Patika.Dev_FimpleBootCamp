using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Abstraction
{
    public interface ILibrary
    {
        // Kitap listeleme işlemi
        void ListBooks();

        // Kitap ekleme işlemi
        void AddBook(string title, string author, int publicationYear);

        // Kitap silme işlemi
        void RemoveBook(int bookId);

        //Üye listeleme işlemi
        void ListMembers();

        // Üye ekleme işlemi
        void AddMember(string firsName, string lastName);

        // Üye silme işlemi
        void RemoveMember(int memberId);

        // Üye üzerindeki kitapları listele
        void ListBorrowedBooks(int memberId);

        // Kitap ödünç verme işlemi
        void LendBook(int memberId, int bookId);

        // Kitap iade etme işlemi
        void ReturnBook(int memberId, int bookId);
    }
}
