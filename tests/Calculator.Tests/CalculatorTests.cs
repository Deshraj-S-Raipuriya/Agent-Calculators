using System;
using Calculator.Core.Services;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private readonly CalculatorService _calculator;

        public CalculatorTests()
        {
            _calculator = new CalculatorService();
        }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(-5, 3, -2)]
        [InlineData(0, 0, 0)]
        public void Add_ShouldReturnCorrectSum_ForIntegers(int a, int b, int expected)
        {
            var result = _calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5.5, 3.3, 8.8)]
        [InlineData(-5.5, 3.3, -2.2)]
        public void Add_ShouldReturnCorrectSum_ForDoubles(double a, double b, double expected)
        {
            var result = _calculator.Add(a, b);
            Assert.Equal(expected, result, 3); // Compare with precision of 3 decimal places
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-5, 3, -8)]
        [InlineData(0, 0, 0)]
        public void Subtract_ShouldReturnCorrectDifference_ForIntegers(int a, int b, int expected)
        {
            var result = _calculator.Subtract(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 3, 15)]
        [InlineData(-5, 3, -15)]
        [InlineData(0, 5, 0)]
        public void Multiply_ShouldReturnCorrectProduct_ForIntegers(int a, int b, int expected)
        {
            var result = _calculator.Multiply(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(-6, 2, -3)]
        [InlineData(0, 5, 0)]
        public void Divide_ShouldReturnCorrectQuotient_ForIntegers(int a, int b, int expected)
        {
            var result = _calculator.Divide(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ShouldThrowException_WhenDividingByZero()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
        }

        [Theory]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(float))]
        [InlineData(typeof(double))]
        [InlineData(typeof(int))]
        [InlineData(typeof(long))]
        public void Calculator_ShouldSupportMultipleNumericTypes(Type numericType)
        {
            dynamic a = Convert.ChangeType(10, numericType);
            dynamic b = Convert.ChangeType(5, numericType);

            var sum = _calculator.Add(a, b);
            var difference = _calculator.Subtract(a, b);
            var product = _calculator.Multiply(a, b);
            var quotient = _calculator.Divide(a, b);

            Assert.IsType(numericType, sum);
            Assert.IsType(numericType, difference);
            Assert.IsType(numericType, product);
            Assert.IsType(numericType, quotient);
        }
    }
}
