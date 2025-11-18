using LSP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Domain.Entities
{
    
    /// <summary>
    /// Permanent employees are bonus-eligible.
    /// </summary>
    public sealed class PermanentEmployee : IEmployee, IBonusEligible
    {
        public string Id { get; }
        public string Name { get; }

        public decimal BasicPay { get; }
        public decimal Hra { get; }
        public decimal SpecialAllowance { get; }
        public decimal BonusRate { get; } // e.g., 10% of (Basic + HRA + Allowance)

        public PermanentEmployee(
            string id,
            string name,
            decimal basicPay,
            decimal hra,
            decimal specialAllowance,
            decimal bonusRate)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BasicPay = basicPay;
            Hra = hra;
            SpecialAllowance = specialAllowance;
            BonusRate = bonusRate;
        }

        public decimal CalculateMonthlySalary()
            => BasicPay + Hra + SpecialAllowance;

        public decimal CalculateBonus()
            => CalculateMonthlySalary() * BonusRate;
    }
}