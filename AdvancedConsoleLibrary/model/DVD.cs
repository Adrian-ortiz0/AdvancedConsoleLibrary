using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    class DVD : Resource , ILoanable
    {
        

        public int Duration { get; set; }
        public String DirectorName { get; set; }

        public DVD(long id, string title, int publicationYear, int duration, String directorName) : base(id, title, publicationYear)
        {
            Duration = duration;
            DirectorName = directorName;
        }


        public override string MostrarInfo()
        {
            return base.MostrarInfo() + $"Duration: {Duration} | Director: {DirectorName}";
        }

        public void Loan(User user)
        {
            throw new NotImplementedException();
        }

        public void Return()
        {
            throw new NotImplementedException();
        }
    }
}
