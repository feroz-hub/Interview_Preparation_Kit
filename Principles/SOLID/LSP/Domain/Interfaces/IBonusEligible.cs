using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Domain.Interfaces
{

    /// <summary>
    /// Separate capability for employees who are bonus-eligible (ISP).
    /// </summary>
    public interface IBonusEligible
    {
        /// <summary>
        /// Returns the monthly bonus amount.
        /// </summary>
        decimal CalculateBonus();
    }

}
