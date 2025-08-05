using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static StudentMangmentSystem.Student_System;


namespace StudentMangmentSystem
{
    public struct Student_address
    {

        public string StuAddress;

        public Student_address(string address)
        {

            this.StuAddress = address;

        }

    }

    public class Student_System
    {

        public string Name;
        public string ID;
        public double Grade;


        public enum Department
        {

            IT, CS, IS, SE

        }

        public Department departstudent { get; set; }
        public Student_address Address { get; set; }

        public Student_System(string Name, string ID, double Grade)
        {

            this.Name = Name;
            this.ID = ID;
            this.Grade = Grade;




        }



        public static void Addstudent(Student_System[] student, ref int i)
        {

            Console.Write("Enter ID: ");// المتغيرات البسيطه مش محتاجه new
            string id = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Grade: ");
            double grade = double.Parse(Console.ReadLine());


            Console.Write("select Department (0=IT, 1=CS, 2=IS, 3=SE): ");
            Department department = (Department)int.Parse(Console.ReadLine());

            Console.Write("Enter Street: ");
            string street = Console.ReadLine();

            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.Write("Enter Postal Code: ");
            string postal_code = Console.ReadLine();
            Console.WriteLine("\n");

            student[i] = new Student_System(name, id, grade);//   newلازم  (class)  هنا انشأنا الكائن والكائنات


            student[i].departstudent = department;//هنا بنستدععى خاصيه جوا الكائن الأنشأناه 

            student[i].Address = new Student_address($"{street}, {city}, {postal_code}");//  student[i] ونخزنها داخل الكائن  (value type)ودا عبره عنstruct  اللى هو اصلا Student_addressبننشئ نسخة جديدة من
            i++;

        }

        public static void View_Students(Student_System[] student, ref int i)
        {
            for (int j = 0; j < i; j++)
            {


                Console.WriteLine($"ID: {student[j].ID}");
                Console.WriteLine($"Name: {student[j].Name}");
                Console.WriteLine($"ID: {student[j].departstudent}");
                Console.WriteLine($"Grade: {student[j].Grade}");
                Console.WriteLine($"Address: {student[j].Address.StuAddress}\n");

            }
        }

    }

    class Program
    {

        static void Main(string[] args)
        {

            Student_System[] student = new Student_System[1000];//هنا انشأنا مصفوفه من الكاءنات 
            int i = 0;

            bool Exist = false;
            int choice;
            do
            {
                Console.WriteLine("--- Student Management Menu ---");

                Console.Write("1. Add Student\r\n2. View Students\r\n3. Delete Student\r\n4. Exit\r\nEnter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");



                switch (choice)
                {
                    case 1:
                        Student_System.Addstudent(student, ref i);
                        Console.WriteLine("Student had added successfuly\n");

                        break;

                    case 2:
                        Student_System.View_Students(student, ref i);

                        break;

                    case 3:
                        Console.Write($"Enter ID: ");
                        string deletStudent = Console.ReadLine();
                        Console.WriteLine();
                        bool found = false;
                        for (int j = 0; j < i; j++)
                        {
                            if (deletStudent == student[j].ID && student[j] != null)
                            {
                                found = true;
                                for (int q = j; q < i; q++)
                                {
                                    student[q] = student[q + 1];

                                }

                                student[i - 1] = null;
                            }

                        }

                        if (found)
                        {
                            Console.WriteLine("Student has succefuly  Deleted\n");
                        }

                        break;

                    case 4:

                        Exist = true;
                        Console.WriteLine("The program has successfly Eixised");


                        break;

                    default:
                        while (choice < 1 || choice > 4)
                        {
                            Console.Write("Invalid Input\nEnter your choice: ");
                            choice = int.Parse(Console.ReadLine());
                        }
                        break;

                }


            } while (!Exist);





        }
    }
}
