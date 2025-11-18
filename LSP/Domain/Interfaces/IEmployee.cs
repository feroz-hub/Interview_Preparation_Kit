using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Domain.Interfaces
{

    /// <summary>
    /// Base abstraction for *all* employees.
    /// Only include members that every employee must support (LSP).
    /// </summary>
    public interface IEmployee
    {
        string Id { get; }
        string Name { get; }

        /// <summary>
        /// Returns total monthly compensation (excluding bonus).
        /// </summary>
        decimal CalculateMonthlySalary();
    }

}
