# C# Coding Standards

## Naming Conventions

**Classes and Methods**: Use PascalCase.

```csharp
// Good
public class CustomerOrder { }
public void ProcessOrder() { }

// Bad
public class customerOrder { }
public void processorder() { }
```

**Variables and Fields**: Use camelCase.

```csharp
// Good
private int orderCount;
public string customerName;

// Bad
private int OrderCount;
public string CustomerName;
```

**Constants**: Use UPPER_CASE.

```csharp
// Good
public const int MAX_ORDERS = 100;

// Bad
public const int MaxOrders = 100;
```

**Namespaces**: Use PascalCase. Match the folder structure. Use file-scoped syntax.

```csharp
// Preferred: File-scoped syntax
namespace MyApp.Services;

// Less preferred: Block-scoped syntax
namespace MyApp.Services
{
    // code
}
```

## Formatting

**Line Length**: Limit lines to 120 characters.

**Braces**: Use Allman style (braces on a new line).

```csharp
// Good
public class Example
{
    public void Method()
    {
        // code
    }
}

// Bad
public class Example {
    public void Method() {
        // code
    }
}
```

**Spacing**: Use a single space before and after operators, and after commas.

```csharp
// Good
int sum = a + b;
var list = new List<int> { 1, 2, 3 };

// Bad
int sum=a+b;
var list = new List<int>{1,2,3};
```

**Variable types**: Use `var` rather than type.

```csharp
// Good
var foo = 2112;
var account = new Account();
var list = new List<int> { 1, 2, 3 };

// Bad
int foo = 2112;
Account account = new Account();
List<int> list = new List<int> { 1, 2, 3 };
```

## Commenting

Basely sufficient comments. Prefer WHY comments and good names over boilerplate comments.

**XML Comments**: Use XML comments (`///`) for public members.

```csharp
/// <summary>
/// Processes the order.
/// </summary>
public void ProcessOrder() { }

// Get or set the Account ID. (bad)
public int AccountID { get; set; }
```

**WHY Comments**: Explain the reasoning behind a piece of code, especially if it's not immediately obvious.

```csharp
// Good
public class OrderService
{
    public void ProcessOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        // WHY: We need to validate the order before processing to ensure all required fields are filled.
        ValidateOrder(order);
        // process order
    }

    private void ValidateOrder(Order order)
    {
        // validation logic
    }
}

// Bad
public class OrderService
{
    public void ProcessOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        ValidateOrder(order); // validate order
        // process order
    }

    private void ValidateOrder(Order order)
    {
        // validation logic
    }
}
```

**Inline Comments**: Use `//` for inline comments and place them above the code they reference.

```csharp
// Calculate the total
int total = a + b;
```

## Error Handling

**Exceptions**: Use exceptions for error handling, not return codes.

```csharp
// Good
public void ProcessOrder()
{
    if (order == null)
    {
        throw new ArgumentNullException(nameof(order));
    }
}

// Bad
public bool ProcessOrder()
{
    if (order == null)
    {
        return false;
    }
    return true;
}
```

**Try-Catch**: Use try-catch blocks to handle exceptions and provide meaningful error messages. Swallowing errors is generally frowned upon - it can lead to bugs that are difficult to track down.

```csharp
// Good
try
{
    // code that may throw an exception
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Bad
try
{
    // code that may throw an exception
}
catch (Exception)
{
    // swallow error
}
```

## Code Structure

**Regions**: Don't Use `#region` to group related pieces of code. If you think you need a `#region` block, you should refactor the code into smaller classes

**File Organization**: One class per file, and the file name should match the class name. Sometimes, if you have a collection of small related classes, you can put them in the same file

## Design

**SOLID Principles**: Follow SOLID principles and design patterns for object-oriented design.

- Single Responsibility Prnciple (SRP)
- Command Pattern

**DRY Principle**: Don't Repeat Yourself. Reuse code wherever possible.

**KISS Principle**: Keep It Simple, Stupid. Write simple and readable code.

**YAGNI Principle**: You Aren't Gonna Need It. Don't add functionality until it is necessary.

## Version Control

**Commit Messages**: Write clear and concise commit messages.

**Branching**: Use feature branches for new features and bug fixes.

## Testing

**Unit Tests**: Write unit tests for all public methods.

**Test Coverage**: Aim for high test coverage but prioritize meaningful tests over coverage percentage.
