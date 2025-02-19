using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    abstract class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public String Cedula {  get; set; }

        public List<Resource> Loans { get; set; }

        public User()
        {

        }

        protected User(Guid id, string name, List<Resource> loans, string cedula)
        {
            Id = id;
            Name = name;
            Loans = loans;
            Cedula = cedula;
        }

        public abstract void LoanResource(Resource resoruce);

        public void ReturnResource()
        {
            if (Loans.Count <= 0)
            {
                Console.WriteLine("There are no resources to return");
                return;
            }

            for (int i = 0; i < Loans.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Loans[i].Title);
            }

            if (int.TryParse(Console.ReadLine(), out int selectedResource) && selectedResource > 0 && selectedResource <= Loans.Count)
            {
                Resource resource = Loans[selectedResource - 1];
                Loans.Remove(resource);
                Console.WriteLine("The resource was returned");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void ListLoans()
        {
            if (Loans.Count <= 0)
            {
                Console.WriteLine("There are no resources to return");
            }

            for (int i = 0; i < Loans.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Loans[i].Title);
            }
        }

    }
}
