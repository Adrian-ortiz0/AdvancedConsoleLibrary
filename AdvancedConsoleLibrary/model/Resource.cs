using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    abstract class Resource
    {
        public long Id { get; set; }
        public String Title { get; set; }
        public int PublicationYear { get; set; }

        protected Resource(long id, string title, int publicationYear)
        {
            Id = id;
            Title = title;
            PublicationYear = publicationYear;
        }

        public virtual String MostrarInfo()
        {
            return $"ID: {Id} | Title: {Title} | Year: {PublicationYear}";
        }
    }
}
