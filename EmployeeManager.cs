using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PayrollTeam3Project
{
    public class EmployeeManager
    {
        // List to store Employee objects
        private readonly List<Employee> employees;

        // Constructor
        public EmployeeManager()
        {
            employees = new List<Employee>();
        }

        // Methods

        // Adds a new employee to the list
        public void AddEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentException("Invalid data entered.");
            }

            // Check for existing employee ID
            if (employees.Any(e => e.EmployeeID == emp.EmployeeID))
            {
                throw new ArgumentException($"Employee with ID {emp.EmployeeID} already exists.");
            }

            employees.Add(emp);
            MessageBox.Show($"Employee {emp.Name} added successfully.");
        }

        // Updates the details of an existing employee
        public void UpdateEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentException("Invalid data entered.");
            }

            // Check if the existing employee is in the list
            var existingEmployee = employees.FirstOrDefault(e => e.EmployeeID == emp.EmployeeID)??throw new ArgumentException($"Employee with ID {emp.EmployeeID} not found.");

            // Update the employee details
            existingEmployee.UpdateEmployee(emp.Name, emp.HourlyRate, emp.HoursWorked, emp.FederalTax, emp.StateTax);
            MessageBox.Show($"Employee {emp.Name} updated successfully.");
        }

        // Removes an employee by their ID
        public void DeleteEmployee(int empID)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeID == empID)??throw new ArgumentException($"Employee with ID {empID} not found.");
            employees.Remove(employee);
            MessageBox.Show($"Employee with ID {empID} removed successfully.");
        }

        // Retrieves an employee by their ID
        public Employee ViewEmployee(int empID)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeID == empID)??throw new ArgumentException($"Employee with ID {empID} not found.");
            return employee; // Return the employee object if found
        }

        // Retrieves all employees
        public List<Employee> GetAllEmployees()
        {
            if (!employees.Any())
            {
                return new List<Employee>(); // Return an empty list if none are found
            }

            return employees; // Return the list of employees
        }
    }
}