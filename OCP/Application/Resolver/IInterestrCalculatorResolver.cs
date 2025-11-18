using OCP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCP.Application.Resolver
{

    public interface IInterestCalculatorResolver
    {
        IInterestCalculator Resolve(string accountTypeKey);
    }

}
