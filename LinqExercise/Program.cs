using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("Print sum of numbers array");
            Console.WriteLine();
            Console.WriteLine(numbers.Sum());

            Console.WriteLine("*************************************************");
            //TODO: Print the Average of numbers
            Console.WriteLine("Print average of numbers array");
            Console.WriteLine();
            Console.WriteLine(numbers.Average());
            Console.WriteLine("*************************************************");
            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ascending Order");
            Console.WriteLine();
            var ascOrder = numbers.OrderBy(num => num);
            foreach (var num in ascOrder)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in decsending order adn print to the console
            Console.WriteLine("*************************************************");
            Console.WriteLine("Descending Order");
            Console.WriteLine();
            var desOrder = numbers.OrderBy(num => num);
            foreach (var num in desOrder)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("*************************************************");
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers greater than six in array");
            Console.WriteLine();
            var sixOrMore = numbers.Where(num => num > 6);
            foreach (var num in sixOrMore)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("*************************************************");
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print 4 numbers");
            Console.WriteLine();
            foreach (var num in ascOrder.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("*************************************************");
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 24;
            numbers.SetValue(24, 4);
            Console.WriteLine("Changed index 4,sort by descending");
            Console.WriteLine();
            var desAge = numbers.OrderByDescending(num => num);
            
            foreach(var number in desAge)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("*************************************************");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            Console.WriteLine("*************************************************");
            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            Console.WriteLine("FirstName that starts with s or c");
            Console.WriteLine();
            var nameFilter = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's').OrderBy(person => person.FirstName);
            var otherFilter = employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's').OrderBy(name => name.FirstName);

            foreach(var person in nameFilter)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine("*************************************************");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over the age of 26");
            Console.WriteLine();
            var employeeAge = employees.Where(employee => employee.Age >26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);

            foreach(var emp in employeeAge)
            {
                Console.WriteLine($"Name: {emp.FullName},\n Age: {emp.Age}");
            }
            Console.WriteLine("*************************************************");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("Sum and Average of employees year of experience");
            var sumYOE = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35);

            Console.WriteLine();
            Console.WriteLine($"Total Years of Expereince: {sumYOE.Sum(e => e.YearsOfExperience)}");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
            Console.WriteLine($"Average Years of Experience: {sumYOE.Average(e => e.YearsOfExperience)}");
            Console.WriteLine("*************************************************");
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Add employee to end of list");
            employees = employees.Append(new Employee("Gary", "Li", 24, 1)).ToList();
            Console.WriteLine("*************************************************");
            Console.WriteLine();
            foreach(var item in employees)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
