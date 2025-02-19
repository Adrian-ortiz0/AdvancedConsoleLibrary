using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    class Magazine : Resource
    {
        

        public int EditionNumber { get; set; }
        public String Periodicity { get; set; }

        public Magazine(long id, string title, int publicationYear, int editionNumber, String periodicity) : base(id, title, publicationYear)
        {
            EditionNumber = editionNumber;
            Periodicity = periodicity;
        }


        public override string MostrarInfo()
        {
            return base.MostrarInfo() + $"Edition Number: {this.EditionNumber} | Periodicity: {this.Periodicity}";
        }
    }
}
