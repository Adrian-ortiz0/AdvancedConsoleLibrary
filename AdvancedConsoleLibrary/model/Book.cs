using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    class Book : Resource, ILoanable
    {
        public String Author { get; set; }
        public int Pages { get; set; }

        public String Genre { get; set; }

        public Book(long id, string title, int publicationYear, String author, int pages, String genre) : base(id, title, publicationYear)
        {
            this.Author = author;
            this.Pages = pages;
            this.Genre = genre;

        }

        public override string MostrarInfo()
        {
            return base.MostrarInfo() + $"Author: {Author} | Genre: {Genre} | Pages: {Pages}";
        }

        public void Loan(User user)
        {
            user.Loans.Add(this);
        }

        public void Return()
        {
            throw new NotImplementedException();
        }
    }
}
