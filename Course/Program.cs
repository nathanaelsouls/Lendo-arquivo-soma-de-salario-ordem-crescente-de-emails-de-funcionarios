using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double salaryMore = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            using(StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] employee = sr.ReadLine().Split(',');
                    string name = employee[0];
                    string email = employee[1];
                    double salary = double.Parse(employee[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salary));
                }
            }

            var emails = list.Where(e => e.Salary > salaryMore).OrderBy(e => e.Email).Select(e => e.Email);
            Console.WriteLine("Email of people whose salary is more than " + salaryMore.ToString("F2", CultureInfo.InvariantCulture));
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            var sum = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.Write("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
