
using LibraryManagementSystem.Abstraction;
using LibraryManagementSystem.Models;
using System.Diagnostics;

class Program
{
    static ILibrary library;
    static void Main()
    {
       
        LendingPolicy lendingPolicy = StartUp();
        library = new Library(lendingPolicy);

        while (true)
        {
            MainMenu();

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Geçersiz seçim. Lütfen bir sayı girin.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    BookMenu();
                    break;

                case 2:
                    UserMenu();
                    break;

                case 0:
                    Console.WriteLine("Programdan çıkılıyor.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen menüdeki bir seçimi girin.");
                    break;
            }
        }
    }

    static LendingPolicy StartUp()
    {
        Console.WriteLine(
            @"Kütüphane Yönetim Sistemini Başlatmak İçin Bir Ödünç Alma Politikası Belirleyiniz
(1) Uzun Süreli Ödünç Politikası
(2) Kısa Süreli Ödünç Politikası
(0) Çıkış");

        int choice;
        int.TryParse(Console.ReadLine(), out choice);

        switch(choice)
        {
            case 1:
                return new LongTermLendingPolicy();
            case 2:
                return new ShortTermLendingPolicy();
            default:
                Console.WriteLine("Geçerli Bir Veri Girilmediği İçin Uygulama Kapatılıyor...");
                Console.ReadLine();
                Environment.Exit(0);
                break;
        }

        return new ShortTermLendingPolicy();
    }

    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine(@"    ----Kütüphane Menüsü----
(1) Kitaplar İle İlgili İşlemler
(2) Kullanıcı İle İlgili İşlemler
(0) Uygulamadan Çıkış");
    }

    static void BookSubMenu()
    {
        
        Console.WriteLine(@"    ----Kitap İşlemleri----
(1) Kitap Ekle
(2) Kitapları Listele
(3) Kitap Sil
(4) Bir Kitabı Bir Kullanıcıya Ödünç Ver
(5) Kullanıcıdan Kitabı Teslim Al
(0) Ana Menü");
    }

    static void UserSubMenu()
    {
        
        Console.WriteLine(@"    ----Kullanıcı İşlemleri----
(1) Kullanıcı Ekle
(2) Kullanıcı Sil
(3) Kullanıcıları Listele
(4) Seçilen Kullanıcı Üzerindeki Kitapları Listele
(0) Ana Menü");
    }

    static void BookMenu()
    {
        while (true)
        {
            BookSubMenu();

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Geçersiz seçim. Lütfen bir sayı girin.");
                continue;
            }
            int bookId;
            int memberId;
            switch (choice)
            {
                case 1:
                    Console.Write("Kitap Adı: ");
                    string title = Console.ReadLine();
                    Console.Write("Yazar: ");
                    string author = Console.ReadLine();
                    Console.Write("Yayın Yılı: ");
                    if (!int.TryParse(Console.ReadLine(), out int publicationYear))
                    {
                        Console.WriteLine("Geçersiz yayın yılı. Lütfen bir sayı girin.");
                        break;
                    }

                    library.AddBook(title, author, publicationYear);
                    break;

                case 2:
                    library.ListBooks();
                    break;

                case 3:
                    library.ListBooks();
                    Console.WriteLine("Yukarıdaki Listeden Silmek İstediğiniz Kitap Id Değerini giriniz.");

                    int.TryParse(Console.ReadLine(), out bookId);

                    library.RemoveBook(bookId);
                    break;

                case 4:
                    library.ListBooks();
                    Console.WriteLine("Yukarıdaki Listeden Ödünç Verilecek Kitabı Seçiniz");
                    int.TryParse(Console.ReadLine(), out bookId);

                    library.ListMembers();
                    Console.WriteLine("Yukarıdaki Listeden Ödünç Verilecek Kullanıcıyı Seçiniz");
                    int.TryParse(Console.ReadLine(), out memberId);

                    library.LendBook(memberId, bookId);
                    break;

                case 5:
                    library.ListMembers();
                    Console.WriteLine("Yukarıdaki Listeden Teslim Edecek Kullanıcıyı Seçiniz");
                    int.TryParse(Console.ReadLine(), out memberId);

                    library.ListBorrowedBooks(memberId);
                    Console.WriteLine("Yukarıdaki Listeden Teslim Alınacak Kitabı Seçiniz");
                    int.TryParse(Console.ReadLine(), out bookId);

                    library.LendBook(memberId, bookId);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen menüdeki bir seçimi girin.");
                    break;
            }
        }
    }

    static void UserMenu()
    {
        while (true)
        {
            UserSubMenu();

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Geçersiz seçim. Lütfen bir sayı girin.");
                continue;
            }
            int memberId;
            switch (choice)
            {
                case 1:
                    Console.Write("Kullanıcı Adı: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Kullanıcı Soyadı: ");
                    string lastName = Console.ReadLine();

                    library.AddMember(firstName, lastName);
                    break;

                case 2:
                    library.ListMembers();
                    Console.WriteLine("Yukarıdaki Listeden Silmek İstediğiniz Kullanıcı Id Değerini giriniz.");
                    int.TryParse(Console.ReadLine(), out memberId);

                    library.RemoveMember(memberId);
                    break;

                case 3:
                    library.ListMembers();
                    break;

                case 4:
                    library.ListMembers();
                    Console.WriteLine("Yukarıdaki Listeden Kitaplarını Listelemek Kullanıcı Id Değerini giriniz.");
                    int.TryParse(Console.ReadLine(), out memberId);
                    library.ListBorrowedBooks(memberId);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen menüdeki bir seçimi girin.");
                    break;
            }
        }
    }
}