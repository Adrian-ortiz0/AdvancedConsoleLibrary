using AdvancedConsoleLibrary.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.view
{
    class LibraryMenu
    {

        public Dictionary<Guid, Student> students;
        public Dictionary<Guid, Professor> professors;


        public LibraryMenu(Dictionary<Guid, Student> students, Dictionary<Guid, Professor> professors)
        {
            this.students = students;
            this.professors = professors;
        }

        public void Menu(List<Resource> resources)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Adrian's Library!");
                Console.WriteLine();
                Console.WriteLine("1. Loans");
                Console.WriteLine("2. Returns");
                Console.WriteLine("3. All Students");
                Console.WriteLine("4. All Professors");
                Console.WriteLine("5. All Personal resources");
                Console.WriteLine("0. Exit");
                try
                {

                    int input = Convert.ToInt32(Console.ReadLine());

                    if (input == 0)
                    {
                        Console.WriteLine("Closing");
                        break;
                    }

                    switch (input)
                    {
                        case 1:
                            LoansMenu(resources);
                            break;
                        case 2:
                            ReturnResources();
                            break;
                        case 3:
                            AllStudents(students);
                            break;
                        case 4:
                            AllProfessors(professors);
                            break;
                        case 5:
                            AllPersonalResources();
                            break;
                        default:
                            Console.WriteLine("Not valid option");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message} Incorrect value. Try again please!");
                }
            }
        }

        public void AllPersonalResources()
        {
            List<User> users = new List<User>();
            foreach (var student in students)
            {
                users.Add(student.Value);
            }
            foreach (var professor in professors)
            {
                users.Add(professor.Value);
            }

            Console.WriteLine("Type your cedula");
            String cedula = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.Cedula.Equals(cedula))
                {
                    Console.WriteLine("User: " + user.Name);
                    Console.WriteLine("Your loans");

                    user.ListLoans();

                }
                else
                {
                    Console.WriteLine("User doesn't exists");

                }
            }
        }

        public void ReturnResources()
        {
            List<User> users = new List<User>();

            foreach (var student in students)
            {
                users.Add(student.Value);
            }
            foreach (var professor in professors)
            {
                users.Add(professor.Value);
            }

            Console.WriteLine("Type your cedula");
            String cedula = Console.ReadLine();

            bool userFound = false;

            foreach (var user in users)
            {
                if (user.Cedula.Equals(cedula))
                {
                    userFound = true;
                    Console.WriteLine("User: " + user.Name);
                    Console.WriteLine("Which book do you want to return?");

                    int count = 0;

                    foreach (var resource in user.Loans)
                    {
                        count++;
                        Console.WriteLine($"ID: {count} | Title: {resource.Title}");
                    }

                    if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex > 0 && selectedIndex <= user.Loans.Count)
                    {
                        Resource selectedResource = user.Loans[selectedIndex - 1];
                        user.Loans.Remove(selectedResource);
                        Console.WriteLine("You have returned " + selectedResource.Title);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }

                    break;
                }
            }

            if (!userFound)
            {
                Console.WriteLine("User doesn't exist");
            }
        }

        public void AllStudents(Dictionary<Guid, Student> students)
        {

            if (students.Count <= 0)
            {
                Console.WriteLine("There are no students");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Key} | Name: {student.Value.Name} | Cedula: {student.Value.Cedula}");
            }

        }

        public void AllProfessors(Dictionary<Guid, Professor> professors)
        {

            if (professors.Count <= 0)
            {
                Console.WriteLine("There are no professors");
                return;
            }

            foreach (var professor in professors)
            {
                Console.WriteLine($"ID: {professor.Key} | Name: {professor.Value.Name} | Cedula: {professor.Value.Cedula}");
            }

        }

        public void LoansMenu(List<Resource> resources)
        {
            Console.WriteLine("Type the name of the resource you want to loan");
            String searchName = Console.ReadLine();
            int count = 0;
            foreach (var resource in resources)
            {
                if (!resource.Title.ToLower().Contains(searchName.ToLower()))
                {
                    continue;
                }
                count++;

                Console.WriteLine(resource.Id + ". " + resource.Title);
                Console.WriteLine("Select the resource you want");
                int selectedIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                Resource selectedResource = resources[selectedIndex];
                Console.WriteLine("Resource " + resources[selectedIndex].Title + " was selected");
                Console.WriteLine("Type your cedula");
                String cedula = Console.ReadLine();
                Console.WriteLine("Type your name");
                String name = Console.ReadLine();
                Console.WriteLine("Are you a student or professor? (1. Student | 2.Professor)");
                int typeUser = Convert.ToInt32(Console.ReadLine());
                if (typeUser == 1)
                {
                    Console.WriteLine("Type your Student ID");
                    String studentId = Console.ReadLine();
                    if(studentId.Length < 10)
                    {
                        Console.WriteLine("The student id must contain 10 characters");
                        return;
                    }
                    List<Resource> studentResources = new List<Resource>();
                    Guid studentGuid = Guid.NewGuid();
                    User student = new Student(studentGuid, name, studentResources, cedula, studentId);
                    studentResources.Add(selectedResource);
                    Console.WriteLine("Resource was loeaned succesfully!");
                    students[studentGuid] = (Student)student;
                    Console.WriteLine("The student was registered");
                }
                else if (typeUser == 2)
                {
                    Console.WriteLine("Type your Professor ID");
                    String professorId = Console.ReadLine();
                    if(professorId.Length < 5)
                    {
                        Console.WriteLine("The professor id must contain 5 characters");
                        return;
                    }
                    List<Resource> professorResources = new List<Resource>();
                    Guid professorGuid = Guid.NewGuid();
                    User professor = new Professor(professorGuid, name, professorResources, cedula, professorId);
                    professorResources.Add(selectedResource);
                    Console.WriteLine("Resource was loeaned succesfully!");
                    professors[professorGuid] = (Professor)professor;
                    Console.WriteLine("The professor was registered");
                } else
                {
                    Console.WriteLine("That command doesn't exists");
                }

            }
            if (count == 0)
            {
                Console.WriteLine("The resource doesn't exists");
            }

        }


    }
    
}
