// Filename  Employee.cs
// Asgnmnt   Final Project
// Written by Erick Semones
// Written on 9-24-2024

/* Creates employee class for employee 
instantiation. Includes attributes for
employeeID, name, hourlyRate, hoursWorked,
federalTax, stateTax, grossPay, and netPay.
Methods include: addEmployee(), updateEmployee(),
removeEmployee(), viewEmployee(), calculatePay(),
and generateReport(). */



using System;

namespace PayrollSystem
{
    public class Employee
    {
        // Private attributes
        private int employeeID;
        private string name;
        private decimal hourlyRate;
        private double hoursWorked;
        private decimal federalTax;
        private decimal stateTax;
        private decimal grossPay;
        private decimal netPay;

        // Constants
        private const decimal MIN_RATE = 7.25m; // Minimum wage is $7.25 per hour
        private const decimal MIN_FED_TAX = 0.10m; // Minimum federal tax rate is 10%
        private const decimal MIN_STATE_TAX = 0.0305m; // Minimum IN state tax is 3.05%

        // Constructor to initialize employee object
        public Employee(int id, string name, decimal hourlyRate,
            double hoursWorked, decimal federalTax, decimal stateTax)
        {
            this.employeeID = id;
            this.name = name;
            this.hourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
            this.federalTax = federalTax;
            this.stateTax = stateTax;
            CalculatePay();
        }

        // Properties with validation
        public int EmployeeID
        {
            get { return employeeID; }
            set
            {
                if (value > 0) employeeID = value;
                else throw new ArgumentException("Employee ID must be a positive number.");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) name = value;
                else throw new ArgumentException("Name cannot be null or empty.");
            }
        }

        public decimal HourlyRate
        {
            get { return hourlyRate; }
            set
            {
                if (value >= MIN_RATE) hourlyRate = value;
                else throw new ArgumentException($"Hourly rate must be at least {MIN_RATE:C}.");
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                if (value >= 0) hoursWorked = value;
                else throw new ArgumentException("Hours worked cannot be negative.");
            }
        }

        public decimal FederalTax
        {
            get { return federalTax; }
            set
            {
                if (value >= MIN_FED_TAX) federalTax = value;
                else throw new ArgumentException($"Federal tax must be at least {MIN_FED_TAX:P}.");
            }
        }

        public decimal StateTax
        {
            get { return stateTax; }
            set
            {
                if (value >= MIN_STATE_TAX) stateTax = value;
                else throw new ArgumentException($"State tax must be at least {MIN_STATE_TAX:P}.");
            }
        }

        // GrossPay and NetPay are calculated internally
        public decimal GrossPay
        {
            get { return grossPay; }
            private set { grossPay = value; }
        }

        public decimal NetPay
        {
            get { return netPay; }
            private set { netPay = value; }
        }

        // Method to calculate gross and net pay
        public void CalculatePay()
        {
            grossPay = hourlyRate * (decimal)hoursWorked;
            decimal totalDeductions = federalTax + stateTax;
            netPay = grossPay - totalDeductions;
        }

        // Method to view employee details
        public string ViewEmployee()
        {
            return $"Employee ID: {employeeID}\nName: {name}\nHourly Rate: {hourlyRate:C}\n" +
                   $"Hours Worked: {hoursWorked}\nGross Pay: {grossPay:C}\nNet Pay: {netPay:C}";
        }

        // Static method to add a new employee
        public static Employee AddEmployee(int id, string name, decimal hourlyRate,
            double hoursWorked, decimal federalTax, decimal stateTax)
        {
            return new Employee(id, name, hourlyRate, hoursWorked, federalTax, stateTax);
        }

        // Method to update employee details
        public void UpdateEmployee(string newName, decimal newHourlyRate,
            double newHoursWorked, decimal newFederalTax, decimal newStateTax)
        {
            Name = newName;
            HourlyRate = newHourlyRate;
            HoursWorked = newHoursWorked;
            FederalTax = newFederalTax;
            StateTax = newStateTax;
            CalculatePay(); // Recalculate pay after updating
        }

        // Method to delete an employee
        public void DeleteEmployee()
        {
            Console.WriteLine($"Employee {name} (ID: {employeeID}) has been deleted.");
        }

        // Method to generate a report for the employee
        public string GenerateReport()
        {
            return $"Employee Report:\nName: {name}\nGross Pay: {grossPay:C}\n" +
                   $"Federal Tax: {federalTax:C}\nState Tax: {stateTax:C}\nNet Pay: {netPay:C}";
        }
    }
}
