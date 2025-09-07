using System;

namespace Calculator.Core.Interfaces
{
    /// <summary>
    /// Interface defining basic calculator operations
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <typeparam name="T">Type of numbers to add (must be numeric)</typeparam>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Sum of the two numbers</returns>
        T Add<T>(T a, T b) where T : struct;

        /// <summary>
        /// Subtracts second number from first number
        /// </summary>
        /// <typeparam name="T">Type of numbers to subtract (must be numeric)</typeparam>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Difference between the two numbers</returns>
        T Subtract<T>(T a, T b) where T : struct;

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <typeparam name="T">Type of numbers to multiply (must be numeric)</typeparam>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Product of the two numbers</returns>
        T Multiply<T>(T a, T b) where T : struct;

        /// <summary>
        /// Divides first number by second number
        /// </summary>
        /// <typeparam name="T">Type of numbers to divide (must be numeric)</typeparam>
        /// <param name="a">First number (dividend)</param>
        /// <param name="b">Second number (divisor)</param>
        /// <returns>Quotient of the division</returns>
        /// <exception cref="DivideByZeroException">Thrown when attempting to divide by zero</exception>
        T Divide<T>(T a, T b) where T : struct;
    }
}
