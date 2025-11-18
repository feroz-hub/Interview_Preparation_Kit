using OCP.Domain.Interfaces;
using OCP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCP.Infrastructure.Calculators
{
    public sealed class PremiumSavingsInterestCalculator: IInterestCalculator
    {

        public string AccountTypeKey => "PremiumSavings";
        public decimal Calculate(Account account) => account.Balance * 0.055m; // 5.5%

    }
}
