
using SRP.Controllers;
using SRP.Repositories;
using SRP.Services;

class Program
{
    static void Main(string[] args)
    {
        var service = new EmployeeService();
        var repository = new EmployeeRepository();
        var controller = new EmployeeController(service, repository);

        while (true)
        {
            Console.WriteLine("\n1. Add Employee\n2. Show All Employees\n3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    controller.AddEmployee();
                    break;
                case "2":
                    controller.ShowAllEmployees();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
