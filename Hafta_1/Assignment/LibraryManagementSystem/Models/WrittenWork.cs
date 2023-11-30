using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class WrittenWork
    {
        protected int _Id { get; set; }
        protected string _title { get; set; }
        protected string _author { get; set; }
        protected int _publicationYear { get; set; }

        public WrittenWork(int id, string title, string author, int publicationYear)
        {
            _Id = id;
            _title = title;
            _author = author;
            _publicationYear = publicationYear;
        }

        public WrittenWork(int id)
        {
            _Id = id;
        }
    }
}
