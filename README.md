# Calculator Application

A robust calculator application that supports multiple numeric types and follows SOLID principles and clean architecture.

## Pull Request Process

### Automated Review Assignment
- Pull requests are automatically assigned to reviewers
- Two reviewers are randomly selected from:
  - Technical Lead
  - Security Reviewer
  - Code Quality Reviewer

### Required Checks
1. **Security**
   - No secrets or sensitive data in code
   - Input validation for all user inputs
   - Protection against SQL injection
   - Protection against XSS attacks

2. **Code Quality**
   - camelCase naming convention for variables
   - XML documentation for public methods
   - Unit test coverage
   - SOLID principles adherence

### Review Process
1. Create a new branch for your changes
2. Make your changes following the coding standards
3. Submit a pull request using the template
4. Address reviewer feedback
5. Merge after approval

For detailed instructions, see `.github/PULL_REQUEST_TEMPLATE/pull_request_template.md`

## Source Control Guidelines

### Git Ignored Files
The following files and directories are excluded from source control:
- Build outputs (`bin/`, `obj/`)
- IDE-specific files (`.vs/`, `.vscode/`)
- User-specific files (`*.user`, `*.userosscache`)
- Temporary files (`*.swp`, `*.*~`)
- Test results and coverage reports
- NuGet package directories
- Operating system files (`.DS_Store`, `Thumbs.db`)

### Best Practices
1. Never commit sensitive information or secrets
2. Keep binaries out of the repository
3. Commit only source code and project configuration
4. Include necessary documentation and README files
5. Exclude IDE-specific settings unless required for the project

See `.gitignore` file for complete list of excluded items.ports multiple numeric types and follows SOLID principles and clean architecture.

## Features

- User Authentication:
  - Username validation (letters, spaces, and dots only)
  - Proper name formatting and capitalization
  - Personalized greeting
- Supports multiple numeric types:
  - Integer (int)
  - Decimal (decimal)
  - Float (float)
  - Double (double)
- Basic arithmetic operations:
  - Addition
  - Subtraction
  - Multiplication
  - Division
- Input validation and error handling
- Support for up to 100 operations per session
- Unit tests using xUnit framework

## Project Structure

- `Calculator.Core`: Contains the core business logic and interfaces
  - `Interfaces/ICalculator.cs`: Defines the calculator operations
  - `Services/CalculatorService.cs`: Implements the calculator operations
- `Calculator.ConsoleApp`: Console application for user interaction
- `Calculator.Tests`: Unit tests using xUnit

## Design Principles

- **Single Responsibility Principle**: Each class has a single responsibility
- **Open/Closed Principle**: New numeric types can be added without modifying existing code
- **Interface Segregation**: Clear interface definition for calculator operations
- **Dependency Inversion**: Console app depends on interfaces, not concrete implementations

## Running the Application

1. Navigate to the Calculator.ConsoleApp directory
2. Run `dotnet run`
3. Follow the on-screen prompts to:
   - Select a numeric type
   - Choose an operation
   - Enter numbers for calculation

## Running Tests

1. Navigate to the Calculator.Tests directory
2. Run `dotnet test`

## Error Handling

The application handles various error scenarios:
- Invalid number formats
- Division by zero
- Invalid operation selection
- Type validation for numeric operations


- SQL injection best practices for variable names as camel case
- Security
- Sql injection Best practics for variable naes as camel case
- Should nor contain secret 
- No XSS attack

