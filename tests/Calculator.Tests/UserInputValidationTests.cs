using Calculator.Core.Services;
using Xunit;

namespace Calculator.Tests
{
    public class UserValidationTests
    {
        private readonly UserValidationService _userValidation;

        public UserValidationTests()
        {
            _userValidation = new UserValidationService();
        }

        [Theory]
        [InlineData("John")]
        [InlineData("John Doe")]
        [InlineData("J. R. R. Tolkien")]
        [InlineData("Mary Jane Parker")]
        public void ValidateName_ShouldReturnTrue_ForValidNames(string name)
        {
            var result = _userValidation.ValidateName(name);
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("John123")]
        [InlineData("John@Doe")]
        [InlineData("John_Doe")]
        public void ValidateName_ShouldReturnFalse_ForInvalidNames(string name)
        {
            var result = _userValidation.ValidateName(name);
            Assert.False(result);
        }

        [Theory]
        [InlineData("john", "John")]
        [InlineData("JOHN", "John")]
        [InlineData("john doe", "John Doe")]
        [InlineData("jOhN dOe", "John Doe")]
        [InlineData("  john   doe  ", "John Doe")]
        [InlineData("j. r. r. tolkien", "J. R. R. Tolkien")]
        public void FormatName_ShouldReturnProperlyFormattedName(string input, string expected)
        {
            var result = _userValidation.FormatName(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FormatName_ShouldReturnEmptyString_ForInvalidInput(string input)
        {
            var result = _userValidation.FormatName(input);
            Assert.Equal(string.Empty, result);
        }
    }
}
