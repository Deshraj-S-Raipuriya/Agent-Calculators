using System;
using System.Text.RegularExpressions;

namespace Calculator.Core.Services
{
    /// <summary>
    /// Service to validate and handle user input
    /// </summary>
    public class UserValidationService
    {
        /// <summary>
        /// Validates if the provided name contains only letters, spaces, and dots
        /// </summary>
        /// <param name="name">Name to validate</param>
        /// <returns>True if name is valid, false otherwise</returns>
        public bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Regex pattern to match only letters, spaces, and dots
            // ^ - start of string
            // [a-zA-Z. ]+ - one or more letters, dots, or spaces
            // $ - end of string
            var pattern = @"^[a-zA-Z. ]+$";
            return Regex.IsMatch(name, pattern);
        }

        /// <summary>
        /// Formats the name by trimming excess spaces and ensuring proper capitalization
        /// </summary>
        /// <param name="name">Name to format</param>
        /// <returns>Formatted name</returns>
        public string FormatName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            // Trim excess spaces and split by spaces
            var nameParts = name.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            // Capitalize first letter of each part
            for (int i = 0; i < nameParts.Length; i++)
            {
                if (nameParts[i].Length > 0)
                {
                    nameParts[i] = char.ToUpper(nameParts[i][0]) + 
                                  (nameParts[i].Length > 1 ? nameParts[i].Substring(1).ToLower() : "");
                }
            }

            return string.Join(" ", nameParts);
        }
    }
}
