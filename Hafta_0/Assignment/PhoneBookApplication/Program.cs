using PhoneBookApplication.Classes;
using PhoneBookApplication.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            PhoneBookHandler phoneBookHandler = new PhoneBookHandler();
            phoneBookHandler.RunPhoneBook();
                        
        }

    }
}
