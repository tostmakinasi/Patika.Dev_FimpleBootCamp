using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Classes
{
    public class PhoneInfo
    {

        private string _name;
        private string _surname;

        public string PhoneNumber { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = !string.IsNullOrEmpty(value)
                    ? char.ToUpper(value[0]) + value.Substring(1).ToLower()
                    : value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = !string.IsNullOrEmpty(value)
                    ? value.ToUpper()
                    : value;
            }
        }


        public PhoneInfo()
        {
            
        }

        public PhoneInfo(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phone;
        }
    }
}
