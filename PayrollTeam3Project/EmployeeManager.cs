// filename EmployeeManager
// asgnmnt  Team 3 Project
// author   Erick Semones
// date     9-29-2024

/* Manages a list of employees. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PayrollTeam3Project // 'public' is not needed before namespace
{
    public class EmployeeManager
    {
        // List to store Employee objects
        private List<Employee> employees;

        // Constructor
        public EmployeeManager()
        {
            employees = new List<Employee>();
        }

        // Methods

        // Adds a new employee to the list
        public void AddEmployee(Employee emp)
        {
            if (emp == null) // is emp null?
            {
                MessageBox.Show("Invalid data entered.");
                return;
            }

            // does this employee ID already exist?
            if (employees.Any(e => e.EmployeeID == emp.EmployeeID))
            {
                MessageBox.Show($"Employee with ID {emp.EmployeeID} already exists.");
                return;
            }

            employees.Add(emp);
            MessageBox.Show($"Employee {emp.Name} added successfully.");
        }

        // Updates the details of an existing employee
        public void UpdateEmployee(Employee emp)
        {
            if (emp == null) // is emp null?
            {
                MessageBox.Show("Invalid data entered.");
                return;
            }

            // is the existing employee in the list?
            var existingEmployee = employees.FirstOrDefault(e => e.EmployeeID == emp.EmployeeID);
            if (existingEmployee == null)
            {
                MessageBox.Show($"Employee with ID {emp.EmployeeID} not found.");
                return;
            }

            // Update the employee details
            existingEmployee.UpdateEmployee(emp.Name, emp.HourlyRate, emp.HoursWorked, emp.FederalTax, emp.StateTax);
            MessageBox.Show($"Employee {emp.Name} updated successfully.");
        }

        // Removes an employee by their ID
        public void DeleteEmployee(int empID)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeID == empID);
            if (employee == null) // does the employee exist?
            {
                MessageBox.Show($"Employee with ID {empID} not found.");
                return;
            }

            employees.Remove(employee);
            MessageBox.Show($"Employee with ID {empID} removed successfully.");
        }

        // Retrieves an employee by their ID
        public Employee ViewEmployee(int empID)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeID == empID);
            if (employee == null) // does the employee exist?
            {
                MessageBox.Show($"Employee with ID {empID} not found.");
                return null;
            }

            return employee; // Return the employee object if found
        }

        // Retrieves all employees
        public List<Employee> GetAllEmployees()
        {
            if (employees.Count == 0) // is the list empty?
            {
                MessageBox.Show("No employees found.");
            }

            return employees; // Return the list of employees
        }
    }
}
