using System;
using System.Globalization;
using System.Linq;

namespace Assignment03OOP
{
    enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA
    }

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        private char gender;
        public char Gender
        {
            get => gender;
            set
            {
                if (value == 'M' || value == 'F')
                    gender = value;
                else
                    throw new ArgumentException("Gender must be 'M' or 'F'.");
            }
        }
        public SecurityLevel Security { get; set; }
        public decimal Salary { get; set; }
        public HireDate HireDate { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Gender: {Gender}, Security Level: {Security}, Salary: {Salary.ToString("C", CultureInfo.CurrentCulture)}, Hire Date: {HireDate}";
        }
    }

    class HireDate : IComparable<HireDate>
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }

        public int CompareTo(HireDate other)
        {
            return new DateTime(Year, Month, Day).CompareTo(new DateTime(other.Year, other.Month, other.Day));
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }

    class EBook : Book
    {
        public double FileSize { get; set; } // in MB
    }

    class PrintedBook : Book
    {
        public int PageCount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Q1. Employee Class Implementation
            Employee emp1 = new Employee
            {
                ID = 1,
                Name = "Mohamed",
                Gender = 'M',
                Security = SecurityLevel.DBA,
                Salary = 5000,
                HireDate = new HireDate { Day = 12, Month = 5, Year = 2020 }
            };

            Employee emp2 = new Employee
            {
                ID = 2,
                Name = "Ahmed",
                Gender = 'M',
                Security = SecurityLevel.Guest,
                Salary = 3000,
                HireDate = new HireDate { Day = 23, Month = 8, Year = 2021 }
            };

            Employee emp3 = new Employee
            {
                ID = 3,
                Name = "Zeyad",
                Gender = 'M',
                Security = SecurityLevel.Secretary,
                Salary = 4000,
                HireDate = new HireDate { Day = 15, Month = 3, Year = 2019 }
            };

            Console.WriteLine(emp1);
            Console.WriteLine(emp2);
            Console.WriteLine(emp3);
            #endregion

            #region Q2. HireDate Class Implementation
            HireDate date1 = new HireDate { Day = 15, Month = 6, Year = 2018 };
            HireDate date2 = new HireDate { Day = 23, Month = 4, Year = 2015 };
            HireDate date3 = new HireDate { Day = 12, Month = 11, Year = 2020 };

            Console.WriteLine("\nHire Date Examples:");
            Console.WriteLine(date1);
            Console.WriteLine(date2);
            Console.WriteLine(date3);
            #endregion

            #region Q3. Array of Employees
            Employee[] EmpArr = { emp1, emp2, emp3 };
            #endregion

            #region Q4. Sort Employees by Hire Date
            Array.Sort(EmpArr, (x, y) => x.HireDate.CompareTo(y.HireDate));
            Console.WriteLine("\nSorted Employees by Hire Date:");
            foreach (var emp in EmpArr)
            {
                Console.WriteLine(emp);
            }

            // Note: Boxing/unboxing is avoided as we work directly with typed arrays and properties.
            #endregion

            #region Q5. Library Management System
            EBook ebook = new EBook
            {
                Title = "",
                Author = "",
                ISBN = "",
                FileSize = 5
            };

            PrintedBook printedBook = new PrintedBook
            {
                Title = "",
                Author = "",
                ISBN = "",
                PageCount = 20
            };

            Console.WriteLine("\nEBook Details:");
            Console.WriteLine($"Title: {ebook.Title}, Author: {ebook.Author}, ISBN: {ebook.ISBN}, File Size: {ebook.FileSize} MB");

            Console.WriteLine("\nPrinted Book Details:");
            Console.WriteLine($"Title: {printedBook.Title}, Author: {printedBook.Author}, ISBN: {printedBook.ISBN}, Page Count: {printedBook.PageCount}");
            #endregion
        }
    }
}
