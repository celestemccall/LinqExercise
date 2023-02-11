using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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

            var sum = numbers.Sum();

            Console.WriteLine($"Sum: {sum}");

            //TODO: Print the Average of numbers

            var average = numbers.Average();

            Console.WriteLine($"Average: {average}");

            //TODO: Order numbers in ascending order and print to the console

            var ascending = numbers.OrderBy(number => number);

            foreach(var num in ascending)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("-------------------------");

            //TODO: Order numbers in decsending order and print to the console

            var descending = numbers.OrderByDescending(number => number);

            foreach (var num in descending)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("-------------------------");

            //TODO: Print to the console only the numbers greater than 6

            var greaterThan = numbers.Where(num => num > 6);

            foreach(var number in greaterThan)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("-------------------------");

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var ascending4 = numbers.OrderBy(number => number).Where(num => num < 4);

            foreach (var num in ascending4)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("-------------------------");

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 29;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------");


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var firstNameCS =
                employees.Where(name => name.FirstName.StartsWith('C') || name.FirstName.StartsWith('S'))
                .OrderBy(name => name.FirstName);

            foreach (var person in firstNameCS)
            {
                Console.WriteLine(person.FullName);
            }

            Console.WriteLine("-------------------------");

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var NameAndAge = employees.Where(age => age.Age > 26).OrderBy(age => age.Age).ThenBy(name => name.FirstName);

            foreach(var person in NameAndAge)
            {
                Console.WriteLine(person.Age);
                Console.WriteLine(person.FullName);
            }

            Console.WriteLine("-------------------------");

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var empYearsOfExperience = employees.Where(years => years.YearsOfExperience <= 10 && years.Age > 35);
            var sumOfYOE = empYearsOfExperience.Sum(emp => emp.YearsOfExperience);
            var averageOfYOE = empYearsOfExperience.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum: {sumOfYOE} Average: {averageOfYOE}");
            Console.WriteLine("-------------------------");

            //TODO: Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Celeste", "McCall", 29, 1)).ToList();

            foreach(var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.Age}");
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
