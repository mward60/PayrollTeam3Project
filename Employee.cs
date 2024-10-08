﻿using System;
using static System.Console;

namespace PayrollTeam3Project
{
    public class Employee
    {
        // fields
        private int employeeID;
        private string name;
        private decimal hourlyRate;
        private decimal federalTax;
        private decimal stateTax;
        private decimal grossPay;
        private decimal netPay;
        private double hoursWorked;
        internal static string Text;
        private const decimal MIN_RATE = 7.25M; // minimum wage is $7.25 per hour
        private const decimal MIN_FED_TAX = 0.10M; // minimum federal tax rate is 10%
        private const decimal MIN_STATE_TAX = 0.0305M; // minimum IN state tax is 3.05%
        private const decimal MAX_TAX_RATE = 1.00M; // tax rate limit is at 100%
        

        // constructor
        public Employee(int id, string name, decimal hourlyRate,
          double hoursWorked, decimal fedTax, decimal stateTax)
        {
            EmployeeID = id;
            Name = name;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
            FederalTax = fedTax;
            StateTax = stateTax;
            CalculatePay();
        }

        // properties
        public int EmployeeID
        {
            get { return employeeID; }
            set
            {
                // is the value of employeeID positive?
                if (value > 0)
                {
                    employeeID = value;
                }
                else
                {
                    throw new ArgumentException("Employee ID must be a positive number.");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                // is the entered string null or empty?
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
            }
        }

        public decimal HourlyRate
        {
            get => hourlyRate;
            set
            {
                if (value >= MIN_RATE)
                {
                    hourlyRate = value;
                }
                else
                {
                    throw new ArgumentException($"Hourly rate must be at least ${MIN_RATE}.");
                }
            }
        }

        public double HoursWorked { get; private set; }

        public decimal FederalTax
        {
            get => federalTax;
            private set
            {
                if (value >= MIN_FED_TAX1 && value <= MAX_TAX_RATE)
                {
                    federalTax = value;
                }
                else
                {
                    throw new ArgumentException($"Federal tax must be between {MIN_FED_TAX1} and {MAX_TAX_RATE}.");
                }
            }
        }

        public decimal StateTax
        {
            get => stateTax;
            private set
            {
                if (value >= MIN_STATE_TAX && value <= MAX_TAX_RATE)
                {
                    stateTax = value;
                }
                else
                {
                    throw new ArgumentException($"State tax must be between {MIN_STATE_TAX} and {MAX_TAX_RATE}.");
                }
            }
        }

        public decimal GrossPay
        {
            get { return grossPay; }
            private set // gross pay is calculated only within the class
            {
                grossPay = value;
            }
        }

        public decimal NetPay
        {
            get { return netPay; }
            private set // net pay is calculated only within the class
            {
                netPay = value;
            }
        }

        public static decimal M { get; private set; }

        public static decimal MIN_RATE1 => MIN_RATE;

        public static decimal MIN_FED_TAX1 => MIN_FED_TAX;

        // methods
        // calculate gross and net pay
        public void CalculatePay()
        {
            grossPay = hourlyRate * (decimal)hoursWorked;
            netPay = grossPay - CalculateDeductions();
        }

        private decimal CalculateDeductions()
        {
            decimal federalTaxAmount = grossPay * federalTax;
            decimal stateTaxAmount = grossPay * stateTax;
            return federalTaxAmount + stateTaxAmount;
        }

        // view employee details
        public string ViewEmployee()
        {
            return $"Employee ID: {employeeID}\nName: {name}\nHourly Rate: {hourlyRate:C}\n" +
                $"Hours Worked: {hoursWorked}\nGross Pay: {grossPay:C}\nNet Pay: {netPay:C}";
        }

        // add employee (could be used with Windows Form)
        public static Employee AddEmployee(int id, string name, decimal hourlyRate,
            double hoursWorked, decimal federalTax, decimal stateTax)
        {
            return new Employee(id, name, hourlyRate, hoursWorked, federalTax, stateTax);
        }

        // update employee details
        public void UpdateEmployee(string newName, decimal newHourlyRate,
            double newHoursWorked, decimal newFedTax, decimal newStateTax)
        {
            Name = newName;
            HourlyRate = newHourlyRate;
            HoursWorked = newHoursWorked;
            FederalTax = newFedTax;
            StateTax = newStateTax;
            CalculatePay(); // recalculate pay after updating		
        }

        // delete an employee (implement in EmployeeManager class)
        public void DeleteEmployee()
        {
            WriteLine($"Employee Name: {name} (ID: {employeeID}) has been removed from the system.");
        }

        // generate a report for an employee
        public string GenerateReport()
        {
            return $"Employee Report:\n" +
                    $"Name: {name}\n" +
                    $"Gross Pay: {grossPay:C}\n" +
                    $"Federal Tax: {federalTax:C}\n" +
                    $"State Tax: {stateTax:C}\n" +
                    $"Net Pay: {netPay:C}";
        }
    }
}