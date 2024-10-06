using System;

namespace PayrollTeam3Project
{
    public class PayrollCalculator
    {
        // Method to calculate gross pay
        public double CalculateGrossPay(double hourlyRate, double hoursWorked)
        {
            return hourlyRate * hoursWorked;
        }

        // Method to calculate total tax
        public double CalculateTotalTax(double federalTax, double stateTax)
        {
            return federalTax + stateTax;
        }

        // Method to calculate net pay
        public double CalculateNetPay(double grossPay, double totalTax)
        {
            return grossPay - totalTax;
        }
    }
}
