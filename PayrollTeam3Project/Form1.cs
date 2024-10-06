using System;
using System.Windows.Forms;

namespace PayrollTeam3Project
{
    public partial class Form1 : Form
    {
        private EmployeeManager employeeManager;
        private PayrollCalculator payrollCalculator;

        public Form1()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager();
            payrollCalculator = new PayrollCalculator();
        }

        private void ButtonAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ErrorHandler.ValidateIntegerInput(EmployeeID.Text, out int employeeID))
                {
                    ErrorHandler.ShowError("Please enter a valid Employee ID.");
                    return;
                }

                string name = EmployeeName.Text;

                if (!ErrorHandler.ValidateNumericInput(HourlyRate.Text, out double hourlyRate) ||
                    !ErrorHandler.ValidateNumericInput(HoursWorked.Text, out double hoursWorked) ||
                    !ErrorHandler.ValidateNumericInput(FederalTax.Text, out double federalTax) ||
                    !ErrorHandler.ValidateNumericInput(StateTax.Text, out double stateTax))
                {
                    ErrorHandler.ShowError("Please enter valid numeric values.");
                    return;
                }

                Employee newEmployee = new Employee
                {
                    EmployeeID = employeeID,
                    Name = name,
                    HourlyRate = hourlyRate,
                    HoursWorked = hoursWorked,
                    FederalTax = federalTax,
                    StateTax = stateTax
                };

                employeeManager.AddEmployee(newEmployee);
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private void ButtonViewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ErrorHandler.ValidateIntegerInput(EmployeeID.Text, out int employeeID))
                {
                    ErrorHandler.ShowError("Please enter a valid Employee ID.");
                    return;
                }

                Employee employee = employeeManager.ViewEmployee(employeeID);

                if (employee != null)
                {
                    EmployeeName.Text = employee.Name;
                    HourlyRate.Text = employee.HourlyRate.ToString();
                    HoursWorked.Text = employee.HoursWorked.ToString();
                    FederalTax.Text = employee.FederalTax.ToString();
                    StateTax.Text = employee.StateTax.ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private void ButtonCalculatePay_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ErrorHandler.ValidateIntegerInput(EmployeeID.Text, out int employeeID))
                {
                    ErrorHandler.ShowError("Please enter a valid Employee ID.");
                    return;
                }

                Employee employee = employeeManager.ViewEmployee(employeeID);

                if (employee != null)
                {
                    double grossPay = payrollCalculator.CalculateGrossPay(employee.HourlyRate, employee.HoursWorked);
                    double totalTax = payrollCalculator.CalculateTotalTax(employee.FederalTax, employee.StateTax);
                    double netPay = payrollCalculator.CalculateNetPay(grossPay, totalTax);

                    TotalPay.Text = netPay.ToString("C"); // Format as currency
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError($"An error occurred: {ex.Message}");
            }
        }
    }
}
