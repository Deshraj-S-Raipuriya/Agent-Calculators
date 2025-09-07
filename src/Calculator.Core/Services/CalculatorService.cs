using System;
using Calculator.Core.Interfaces;

namespace Calculator.Core.Services
{
    /// <summary>
    /// Implementation of calculator operations supporting various numeric types
    /// </summary>
    public class CalculatorService : ICalculator
    {
        /// <inheritdoc/>
        public T Add<T>(T a, T b) where T : struct
        {
            if (typeof(T).IsPrimitive || typeof(T) == typeof(decimal))
            {
                dynamic x = a;
                dynamic y = b;
                return x + y;
            }
            throw new ArgumentException("Type must be numeric");
        }

        /// <inheritdoc/>
        public T Subtract<T>(T a, T b) where T : struct
        {
            if (typeof(T).IsPrimitive || typeof(T) == typeof(decimal))
            {
                dynamic x = a;
                dynamic y = b;
                return x - y;
            }
            throw new ArgumentException("Type must be numeric");
        }

        /// <inheritdoc/>
        public T Multiply<T>(T a, T b) where T : struct
        {
            if (typeof(T).IsPrimitive || typeof(T) == typeof(decimal))
            {
                dynamic x = a;
                dynamic y = b;
                return x * y;
            }
            throw new ArgumentException("Type must be numeric");
        }

        /// <inheritdoc/>
        public T Divide<T>(T a, T b) where T : struct
        {
            if (typeof(T).IsPrimitive || typeof(T) == typeof(decimal))
            {
                dynamic x = a;
                dynamic y = b;
                
                if (y == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero");
                }
                
                return x / y;
            }
            throw new ArgumentException("Type must be numeric");
        }
    }
}
