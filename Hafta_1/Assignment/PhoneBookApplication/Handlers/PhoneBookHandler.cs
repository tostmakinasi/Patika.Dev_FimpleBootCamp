using PhoneBookApplication.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Handlers
{
    public class PhoneBookHandler
    {
        private List<PhoneInfo> _phones;

        public PhoneBookHandler()
        {
            _phones = new List<PhoneInfo>();

            _phones.Add(new PhoneInfo("Kubilay", "Cem", "5055055555"));
            _phones.Add(new PhoneInfo("Atilla", "Davran", "5055055555"));
            _phones.Add(new PhoneInfo("Cenk", "Cumagil", "5055055555"));
            _phones.Add(new PhoneInfo("Ata", "Demirel", "5055055555"));
            _phones.Add(new PhoneInfo("Cem", "Davran", "5055055555"));
        }

        private void AddPhone(PhoneInfo phone)
        {
            _phones.Add(phone);
        }

        private void AddPhone(string name, string surname, string phone)
        {
            _phones.Add(new PhoneInfo(name,surname,phone));
        }

        private void DeletePhone(string searchTerm)
        {
            
            var foundPhones = _phones.Where(p => p.Name.ToLower() == searchTerm.ToLower() || p.Surname.ToLower() == searchTerm.ToLower()).ToList();

            if (foundPhones.Count == 0)
            {
                Console.WriteLine("Aranan kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Silmeyi sonlandırdınız.");
                }
                else if (choice == 2)
                {
                    DeletePhone(searchTerm);
                }
            }
            else
            {
                var phoneToDelete = foundPhones.First();
                Console.WriteLine($"{phoneToDelete.Name} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                string confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    _phones.Remove(phoneToDelete);
                    Console.WriteLine("Kişi rehberden silindi.");
                }
                else
                {
                    Console.WriteLine("Silme işlemi iptal edildi.");
                }
            }
        }
        private void UpdatePhone(string searchTerm)
        {
            var foundPhones = _phones.Where(p => p.Name.ToLower() == searchTerm.ToLower() || p.Surname.ToLower() == searchTerm.ToLower()).ToList();

            if (foundPhones.Count == 0)
            {
                Console.WriteLine("Aranan kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                Console.WriteLine("* Yeniden denemek için              : (2)");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Güncelleme işlemini sonlandırdınız.");
                }
                else if (choice == 2)
                {
                    // Yeniden deneme işlemleri
                    UpdatePhone(searchTerm);
                }
            }
            else
            {
                var phoneToUpdate = foundPhones.First();
                Console.WriteLine($"{phoneToUpdate.Name} isimli kişinin yeni telefon numarasını giriniz:");
                string newPhoneNumber = Console.ReadLine();

                phoneToUpdate.PhoneNumber = newPhoneNumber;
                Console.WriteLine("Telefon numarası güncellendi.");
            }
        }

        private void ListPhoneBook()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");

            foreach (var phone in _phones)
            {
                Console.WriteLine($"isim: {phone.Name} Soyisim: {phone.Surname} Telefon Numarası: {phone.PhoneNumber}");
            }

            Console.WriteLine("**********************************************");
        }

        private void SearchPhoneBook(string searchType)
        {
          
            Console.WriteLine($"Arama yapmak istediğiniz tipi seçiniz. İsim veya soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");

            if (choice == 1)
            {
                Console.WriteLine("İsim veya soyisim giriniz:");
                string searchTerm = Console.ReadLine().ToLower();
                var searchResults = _phones.Where(p => p.Name.ToLower().Contains(searchTerm) || p.Surname.ToLower().Contains(searchTerm)).ToList();

                foreach (var result in searchResults)
                {
                    Console.WriteLine($"isim: {result.Name} Soyisim: {result.Surname} Telefon Numarası: {result.PhoneNumber}");
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Telefon numarası giriniz:");
                string searchTerm = Console.ReadLine().ToLower();
                var searchResults = _phones.Where(p => p.PhoneNumber.ToLower().Contains(searchTerm)).ToList();

                foreach (var result in searchResults)
                {
                    Console.WriteLine($"isim: {result.Name} Soyisim: {result.Surname} Telefon Numarası: {result.PhoneNumber}");
                }
            }

            Console.WriteLine("**********************************************");
        }

        private void PerformUserChoice(int choice)
        {
            Console.Clear();
            switch (choice)
            {

                case 1:
                    Console.WriteLine("Lütfen isim giriniz:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Lütfen soy isim giriniz:");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Lütfen telefon numarası giriniz:");
                    string phone = Console.ReadLine();

                    AddPhone(name, surname, phone);
                    Console.WriteLine("Yeni numara başarıyla eklendi.\n");
                    break;

                case 2:
                    Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                    string deleteSearchTerm = Console.ReadLine().ToLower();
                    DeletePhone(deleteSearchTerm);
                    break;

                case 3:
                    Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                    string updateSearchTerm = Console.ReadLine().ToLower();
                    UpdatePhone(updateSearchTerm);
                    break;

                case 4:
                    ListPhoneBook();
                    break;

                case 5:
                    Console.WriteLine("Lütfen arama yapmak istediğiniz tipi seçiniz.");
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("İsim veya soy isime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");
                    int searchTypeChoice = int.Parse(Console.ReadLine());

                    if (searchTypeChoice == 1 || searchTypeChoice == 2)
                    {
                        SearchPhoneBook(searchTypeChoice.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim.");
                    }
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }

        }

        public void RunPhoneBook()
        {
            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek\n(2) Varolan Numarayı Silmek\n(3) Varolan Numarayı Güncelleme\n(4) Rehberi Listelemek\n(5) Rehberde Arama Yapmak\n(0) Çıkış");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 0)
                        exit = true;
                    else
                        PerformUserChoice(choice);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Anlayamadım. Tekrar deneyin...");
                }
                
            }
        }
    }
}
