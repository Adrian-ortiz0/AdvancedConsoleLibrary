using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    class Professor : User
    {
        private String professorId;

        public String ProfessorId
        {
            get { return professorId; }
            set
            {
                if (value.Length < 5)
                {
                    Console.WriteLine("The professor id must contains 5 characters");
                }
                else
                {
                    professorId = value;
                }
            }
        }
        public Professor() { }

        public Professor(Guid id, string name, List<Resource> loans, string cedula, String professorId) : base(id, name, loans, cedula)
        {
            ProfessorId = professorId;
        }

        public override void LoanResource(Resource resoruce)
        {
            if(Loans.Count >= 5)
            {
                Console.WriteLine("You can only have 5 simultaneosly loans");
                return;
            } else
            {
                Loans.Add(resoruce);
                Console.WriteLine("Succesfully loan");
            }
        }
    }
}
