using LSP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Application.Services
{

    /// <summary>
    /// Orchestrates salary-related operations for any employee.
    /// Works with the base abstraction (LSP friendly).
    /// </summary>
    public sealed class PayrollService
    {
        public decimal GetMonthlySalary(IEmployee employee)
            => employee.CalculateMonthlySalary();

        public string GetPayLine(IEmployee employee)
            => $"{employee.Name,-12} | Salary: {employee.CalculateMonthlySalary(),10:C}";
    }
}
