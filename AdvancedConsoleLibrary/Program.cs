using AdvancedConsoleLibrary.model;
using AdvancedConsoleLibrary.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Resource> resources = new List<Resource>();
            Dictionary<Guid, Student> students = new Dictionary<Guid, Student>();
            Dictionary<Guid, Professor> professors = new Dictionary<Guid, Professor>();

            Resource book1 = new Book(1, "It", 1998, "Stephen King", 856, "Horror");
            Resource book2 = new Book(2, "The Shining", 1998, "Stephen King", 856, "Horror");
            Resource book3 = new Book(3, "The Cujo", 1998, "Stephen King", 856, "Horror");
            Resource book4 = new Book(4, "Pet Cemetary", 1998, "Stephen King", 856, "Horror");
            Resource book5 = new Book(5, "The Dome", 1998, "Stephen King", 856, "Horror");

            Resource DVD1 = new DVD(6, "Interestellar", 2015, 200, "Christopher Nolan");
            Resource DVD2 = new DVD(7, "Oppenheimer", 2022, 210, "Christopher Nolan");
            Resource DVD3 = new DVD(8, "Tenet", 2020, 190, "Christopher Nolan");

            resources.Add(book1);
            resources.Add(book2);
            resources.Add(book3);
            resources.Add(book4);
            resources.Add(book5);
            resources.Add(DVD1);
            resources.Add(DVD2);
            resources.Add(DVD3);


            LibraryMenu LibraryMenu = new LibraryMenu(students, professors);

            LibraryMenu.Menu(resources);
        }
    }
}
