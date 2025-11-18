using LSP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Domain.Entities
{
    /// <summary>
    /// Contract employees are NOT bonus-eligible.
    /// Note: No bonus method here — respects LSP by not exposing non-applicable members.
    /// </summary>
    public sealed class ContractEmployee : IEmployee
    {
        public string Id { get; }
        public string Name { get; }

        public decimal HourlyRate { get; }
        public int BillableHours { get; }  // per month

        public ContractEmployee(string id, string name, decimal hourlyRate, int billableHours)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            HourlyRate = hourlyRate;
            BillableHours = billableHours;
        }

        public decimal CalculateMonthlySalary()
            => HourlyRate * BillableHours;
    }
}
