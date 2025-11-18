using SRP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRP.Repositories
{
    public class EmployeeRepository
    {
        private readonly List<Employee> employees = new List<Employee>();
        public void Save(Employee emp)
        {
            employees.Add(emp);
            Console.WriteLine($"Employee{emp.Name} saved to database.");
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

    }
}
