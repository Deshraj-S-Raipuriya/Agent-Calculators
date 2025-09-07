using System;
using Calculator.Core.Interfaces;
using Calculator.Core.Services;

namespace Calculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new CalculatorService();
            var userValidation = new UserValidationService();
            
            Console.WriteLine("Welcome to the Calculator Application!");
            
            string userName;
            do
            {
                Console.Write("\nPlease enter your name (letters, spaces, and dots only): ");
                userName = Console.ReadLine() ?? string.Empty;

                if (!userValidation.ValidateName(userName))
                {
                    Console.WriteLine("Invalid name! Please use only letters, spaces, and dots.");
                }
            } while (!userValidation.ValidateName(userName));

            userName = userValidation.FormatName(userName);
            Console.WriteLine($"\nHello, {userName}! Welcome to our calculator service.");
            Console.WriteLine("This calculator supports multiple number types: int, decimal, float, double");
            
            // Get the desired number type from user
            Console.WriteLine("\nSelect number type:");
            Console.WriteLine("1. Integer (int)");
            Console.WriteLine("2. Decimal (decimal)");
            Console.WriteLine("3. Float (float)");
            Console.WriteLine("4. Double (double)");
            
            Type selectedType = GetNumberType();
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"\nOperation {i + 1} of 100");
                Console.WriteLine("Select operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");

                if (!int.TryParse(Console.ReadLine(), out int operation) || operation < 1 || operation > 5)
                {
                    Console.WriteLine("Invalid operation. Please try again.");
                    i--; // Don't count this as one of the 100 operations
                    continue;
                }

                if (operation == 5)
                {
                    break;
                }

                try
                {
                    Console.Write("Enter first number: ");
                    dynamic firstNumber = ConvertToType(Console.ReadLine(), selectedType);

                    Console.Write("Enter second number: ");
                    dynamic secondNumber = ConvertToType(Console.ReadLine(), selectedType);

                    dynamic result = 0;
                    string operationSymbol = "";

                    switch (operation)
                    {
                        case 1:
                            result = calculator.Add(firstNumber, secondNumber);
                            operationSymbol = "+";
                            break;
                        case 2:
                            result = calculator.Subtract(firstNumber, secondNumber);
                            operationSymbol = "-";
                            break;
                        case 3:
                            result = calculator.Multiply(firstNumber, secondNumber);
                            operationSymbol = "*";
                            break;
                        case 4:
                            result = calculator.Divide(firstNumber, secondNumber);
                            operationSymbol = "/";
                            break;
                    }

                    Console.WriteLine($"\nResult: {firstNumber} {operationSymbol} {secondNumber} = {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number format. Please try again.");
                    i--; // Don't count this as one of the 100 operations
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                    i--; // Don't count this as one of the 100 operations
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    i--; // Don't count this as one of the 100 operations
                }
            }

            Console.WriteLine("\nThank you for using the Calculator!");
        }

        private static Type GetNumberType()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1: return typeof(int);
                        case 2: return typeof(decimal);
                        case 3: return typeof(float);
                        case 4: return typeof(double);
                    }
                }
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            }
        }

        private static dynamic ConvertToType(string input, Type type)
        {
            return Convert.ChangeType(input, type);
        }
    }
}