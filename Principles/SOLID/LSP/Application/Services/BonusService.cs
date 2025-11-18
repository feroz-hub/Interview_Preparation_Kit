using LSP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Application.Services
{

    /// <summary>
    /// Works only with bonus-eligible employees. No casting, no exceptions (LSP).
    /// </summary>
    public sealed class BonusService
    {
        public decimal GetMonthlyBonus(IBonusEligible employee)
            => employee.CalculateBonus();

        public string GetBonusLine(IBonusEligible employee)
            => $"{employee.GetType().Name,-18} | Bonus: {employee.CalculateBonus(),10:C}";
    }
}
