using System;
using System.Windows.Forms;

namespace PayrollTeam3Project
{
    public partial class Form1 : Form
    {
        public EmployeeManager employeeManager;
        public PayrollCalculator payrollCalculator;

        public object TotalPay { get; private set; }

        public Form1()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager();
            payrollCalculator = new PayrollCalculator();
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee newEmployee = GetEmployeeFromInput();

                if (newEmployee == null)
                {
                    ErrorHandler.ShowError("Please enter valid employee details.");
                    return;
                }

                employeeManager.AddEmployee(newEmployee);
                MessageBox.Show("Employee added successfully.");
                ClearInputFields();
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private void BtnViewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ErrorHandler.ValidateIntegerInput(Employee.Text, out int employeeID))
                {
                    ErrorHandler.ShowError("Please enter a valid Employee ID.");
                    return;
                }

                Employee employee = employeeManager.ViewEmployee(employeeID);

                if (employee != null)
                {
                    PopulateInputFields(employee);
                }
                else
                {
                    ErrorHandler.ShowError("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private PayrollCalculator GetPayrollCalculator()
        {
            return PayrollCalculator;
        }

        private void ButtonCalculatePay_Click(object sender, EventArgs e, PayrollCalculator payrollCalculator)
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
                    double grossPay = (double)payrollCalculator.CalculateGrossPay(employee.HourlyRate, employee.HoursWorked);
                    double totalTax = PayrollCalculator.CalculateTotalTax(employee.FederalTax, employee.StateTax);
                    double netPay = PayrollCalculator.CalculateNetPay(grossPay, totalTax);

                    TotalPay.Text = netPay.ToString("C"); // Format as currency
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private void BtnUpdateEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ErrorHandler.ValidateIntegerInput(EmployeeID.Text, out int employeeID))
                {
                    ErrorHandler.ShowError("Please enter a valid Employee ID.");
                    return;
                }

                Employee employee = employeeManager.ViewEmployee(employeeID);

                if (employee == null)
                {
                    ErrorHandler.ShowError("Employee not found.");
                    return;
                }

                Employee updatedEmployee = GetEmployeeFromInput();

                if (updatedEmployee == null)
                {
                    ErrorHandler.ShowError("Please enter valid employee details.");
                    return;
                }

                // Update the employee details
                employee.Name = updatedEmployee.Name;
                employee.HourlyRate = updatedEmployee.HourlyRate;
                employee.HoursWorked = updatedEmployee.HoursWorked;
                employee.FederalTax = updatedEmployee.FederalTax;
                employee.StateTax = updatedEmployee.StateTax;

                employeeManager.UpdateEmployee(employee);
                MessageBox.Show("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private Employee GetEmployeeFromInput()
        {
            if (!ErrorHandler.ValidateIntegerInput(EmployeeID.Text, out int employeeID))
                return null;

            if (!ErrorHandler.ValidateNumericInput(HourlyRate.Text, out double hourlyRate) ||
                !ErrorHandler.ValidateNumericInput(HoursWorked.Text, out double hoursWorked) ||
                !ErrorHandler.ValidateNumericInput(FederalTax.Text, out double federalTax) ||
                !ErrorHandler.ValidateNumericInput(StateTax.Text, out double stateTax))
                return null;

            return new Employee
            {
                EmployeeID = employeeID,
                Name = EmployeeName.Text,
                HourlyRate = hourlyRate,
                HoursWorked = hoursWorked,
                FederalTax = federalTax,
                StateTax = stateTax
            };
        }

        private void PopulateInputFields(Employee employee)
        {
            EmployeeName.Text = employee.Name;
            HourlyRate.Text = employee.HourlyRate.ToString();
            HoursWorked.Text = employee.HoursWorked.ToString();
            FederalTax.Text = employee.FederalTax.ToString();
            StateTax.Text = employee.StateTax.ToString();
        }

        private void ClearInputFields()
        {
            EmployeeID.Clear();
            EmployeeName.Clear();
            HourlyRate.Clear();
            HoursWorked.Clear();
            FederalTax.Clear();
            StateTax.Clear();
            TotalPay.Clear();
        }
    }

    internal class EmployeeID
    {
    }
}
