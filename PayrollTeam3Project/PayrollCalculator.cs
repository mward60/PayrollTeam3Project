using System;

namespace PayrollTeam3Project
{
    public class PayrollCalculator
    {
        // Method to calculate gross pay
        public decimal CalculateGrossPay(decimal hourlyRate, double hoursWorked)
        {
            return hourlyRate * (decimal)hoursWorked;
        }

        // Method to calculate total tax based on gross pay
        public decimal CalculateTotalTax(decimal grossPay, decimal federalTaxRate, decimal stateTaxRate)
        {
            decimal federalTaxAmount = grossPay * federalTaxRate;
            decimal stateTaxAmount = grossPay * stateTaxRate;
            return federalTaxAmount + stateTaxAmount;
        }

        // Method to calculate net pay
        public decimal CalculateNetPay(decimal grossPay, decimal totalTax)
        {
            return grossPay - totalTax;
        }
    }
}