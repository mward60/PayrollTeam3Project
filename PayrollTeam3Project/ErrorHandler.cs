using System;
using System.Windows.Forms;

namespace PayrollTeam3Project
{
    public static class ErrorHandler
    {
    
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
        public static bool ValidateIntegerInput(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

       
        public static bool ValidateNumericInput(string input, out double result)
        {
            return double.TryParse(input, out result);
        }

       
        public static bool ValidateNonEmptyInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
