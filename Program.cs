using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Name = "A", Salary = 50000, Experience = 2 });
            employees.Add(new Employee { Name = "B", Salary = 60000, Experience = 3 });
            employees.Add(new Employee { Name = "C", Salary = 30000, Experience = 5 });
            employees.Add(new Employee { Name = "D", Salary = 20000, Experience = 4 });

            #region use function for delegates
            Console.WriteLine("Use of delegates using functions.");
            Console.WriteLine("Promotion based on sal: ");

            IsPromote isPromoteEmpSal = new IsPromote(IsPromoteEmpSal);
            Employee.PromoteEmployee(employees, isPromoteEmpSal);

            Console.WriteLine();

            Console.WriteLine("Promotion based on experience: ");

            IsPromote isPromoteEmpExp = new IsPromote(IsPromoteEmpExp);
            Employee.PromoteEmployee(employees, isPromoteEmpExp);
            #endregion

            Console.WriteLine();
            Console.WriteLine();

            #region Use lambda expression for delegates
            Console.WriteLine("Use of delegates using lambda expression.");
            Console.WriteLine("Promotion based on sal: ");

            Employee.PromoteEmployee(employees, emp => emp.Salary >= 40000);

            Console.WriteLine();

            Console.WriteLine("Promotion based on experience: ");

            Employee.PromoteEmployee(employees, emp => emp.Experience >= 4);

            #endregion

            Console.ReadLine();
        }

        #region functions for delegates
        public static bool IsPromoteEmpSal(Employee emp)
        {
            return emp.Salary >= 40000;
        }

        public static bool IsPromoteEmpExp(Employee emp)
        {
            return emp.Experience >= 4;
        }
        #endregion
    }

    public delegate bool IsPromote(Employee emp);
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public byte Experience { get; set; }

        public static void PromoteEmployee(List<Employee> employees, IsPromote isPromote)
        {
            foreach (Employee emp in employees)
            {
                if (isPromote(emp))
                    Console.WriteLine(emp.Name);
            }
        }
    }
}
