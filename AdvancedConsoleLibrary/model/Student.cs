using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    class Student : User
    {
        private String studentId;

        public String StudentId
        {
            get { return studentId; }
            set
            {
                if(value.Length < 10)
                {
                    Console.WriteLine("The student id must contains 10 characters");
                } else
                {
                    studentId = value;
                }
            }
        }
        
        public Student()
        {
        }

        public Student(Guid id, string name, List<Resource> loans, string cedula, string studentId) : base(id, name, loans, cedula)
        {
            StudentId = studentId;
        }

        public override void LoanResource(Resource resoruce)
        {
            if(Loans.Count >= 3)
            {
                Console.WriteLine("You can only have 3 simultanealy Loans");
                return;

            } else
            {
                Loans.Add(resoruce);
                Console.WriteLine("Succesfully loan");
            }
        }
    }
}
