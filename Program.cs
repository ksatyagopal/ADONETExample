using System;

namespace ADONETExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Example obj = new Example();
            obj.Initiate();
            obj.SelectData();
            Console.WriteLine("Enter Employee ID:");
            int empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Employee City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary:");
            float salary = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee Department ID:");
            int deptid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Reporting Manager ID:");
            int reportsto = Convert.ToInt32(Console.ReadLine());
            int recordseffected = obj.InsertRecord(empid, name, city, deptid, salary, reportsto);
            Console.WriteLine($"{recordseffected} Row(s) Effected");
            obj.SelectData();
        }
    }
}
