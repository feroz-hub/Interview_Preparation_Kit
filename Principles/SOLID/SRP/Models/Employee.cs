using System;
using System.Collections.Generic;
using System.Text;

namespace SRP.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal BasicSalary { get; set; }

        /*
                ❌ SRP Violation Example:
                This class is doing multiple things:
                - Holding data
                - Calculating salary
                - Saving to database
                This violates SRP because it has more than one reason to change.

                public decimal CalculateSalary()
                {
                    return BasicSalary + (BasicSalary * 0.10m);
                }

                public void SaveToDatabase(Employee emp)
                {
                    // Direct DB logic here
                }
                */

    }
}
