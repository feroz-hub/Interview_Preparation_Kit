using SRP.Models;
using SRP.Repositories;
using SRP.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRP.Controllers
{
    public class EmployeeController(EmployeeService employeeService, EmployeeRepository employeeRepository)
    {
        public void AddEmployee()
        {

            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Department:");
            string dept = Console.ReadLine();

            Console.WriteLine("Enter Basic Salary:");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Employee emp = new Employee { Id = new Random().Next(1, 100), Name = name, Department = dept, BasicSalary = salary };

            decimal totalSalary = employeeService.CalculateSalary(emp);
            Console.WriteLine($"Calculated Salary for {emp.Name}: {totalSalary}");

            employeeRepository.Save(emp);



        }

        public void ShowAllEmployees()
        {
            var employees = employeeRepository.GetAll();
            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Id} | {emp.Name} | {emp.Department} | Basic: {emp.BasicSalary}");
            }
        }


    }

}
