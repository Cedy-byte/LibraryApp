using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Book
    {
        private string name;
        private string author;
        private string publisher;
        private string year;
        private string isbn;

        public Book()
        {
            
        }
        public Book(string name, string author, string publisher, string year, string isbn)
        {
            this.name = name;
            this.author = author;
            this.publisher = publisher;
            this.year = year;
            Isbn = isbn;
        }

        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Year { get => year; set => year = value; }
        public string Isbn { get => isbn; set => isbn = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
