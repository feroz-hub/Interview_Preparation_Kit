using SRP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRP.Services
{
    public class EmployeeService
    {
        public decimal CalculateSalary(Employee emp)
        {
            return emp.BasicSalary +(emp.BasicSalary * 0.10m);
        }
    }
}
