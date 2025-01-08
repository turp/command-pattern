# Project Documentation

## Overview

This project provides a framework for creating and managing compliance controls. Compliance controls are used to ensure that various processes and operations adhere to regulatory and internal standards.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/command.git
   ```
2. Navigate to the project directory:
   ```sh
   cd command
   ```
3. Build the project:
   ```sh
   dotnet build
   ```

## Usage

### Creating New Compliance Controls

To create a new compliance control, follow these steps:

1. Define a new class that implements the `ComplianceControl` abstract class.
2. Implement the required methods and properties.

#### Example

```csharp
using System;

namespace ComplianceControls;
public class C234567 : ComplianceControl
{
    public C234567(IServiceA serviceA, IServiceB serviceB) : base("C234567", "Lorem ipsum dolor sit amet, consectetur adipiscing elit")
    {
        AddChild(new C234567_01(serviceA));
        AddChild(new C234567_02(serviceB));
        AddChild(new C234567_03(serviceA, serviceB));
    }
}
```

### Registering Controls in Dependency Injection

Once you have created a new compliance control, it is automatically registered using `Services.ServiceExtensions` methods which are called in `Program.cs`.

1. Create custom attributes to mark the services.
2. Use reflection to scan and register the services.

### Registering Services in Dependency Injection

When you create a new service, it will be automatically registered in using `Services.ServiceExtensions` methods which are called in `Program.cs`.

You only need to decorate your service class with one of the following attributes:

```csharp
// The service is created once per request and shared within that request
[ScopedService]
// The service is created once and shared across the entire application
[SingletonService]
// The service is created each time it is requested
[TransientService]
```

```csharp
[ScopedService]
public class MyService : IMyService
{
}
```

## Contributing

We welcome contributions! Please read our [contributing guidelines](CONTRIBUTING.md) for more details.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

We welcome contributions! Please read our [contributing guidelines](CONTRIBUTING.md) for more details.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
