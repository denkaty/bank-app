# bank-app

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/bank-app.git
    ```

2. Navigate to the project directory:
    ```bash
    cd bank-app
    ```

3. Restore the dependencies:
    ```bash
    dotnet restore
    ```

### Running the Application

To run the application, use the following command:
```bash
dotnet run
```

## Overview

This is a console application designed to demonstrate the use of various design patterns in a banking context. The application simulates basic banking operations and showcases how different design patterns can be applied in software development.

## Best Practices and Principles

This application follows best practices and adheres to SOLID principles to ensure code quality, maintainability, and extensibility.

### Dependency Injection

Dependency Injection is used throughout the application to promote loose coupling and enhance testability. Services and dependencies are injected where needed, facilitating better modularity and easier unit testing.

### SOLID Principles

- **Single Responsibility Principle (SRP)**: Each class has a single responsibility and encapsulates only the logic related to that responsibility.
- **Open/Closed Principle (OCP)**: Classes are open for extension but closed for modification. New functionality is added by extending existing classes.
- **Liskov Substitution Principle (LSP)**: Subclasses can be substituted for their base classes without affecting the correctness of the program.
- **Interface Segregation Principle (ISP)**: Clients are not forced to depend on interfaces they do not use. Interfaces are split into smaller, more specific ones.
- **Dependency Inversion Principle (DIP)**: High-level modules do not depend on low-level modules. Both depend on abstractions, which allows for more flexible and testable code.

## Features

- Chain of Responsibility
- Command Pattern
- Facade Pattern
- Factory Pattern
- Iterator Pattern
- Proxy Pattern
- Strategy Pattern
- Visitor Pattern
- Logger
- Repositories

## Design Patterns Used

### Chain of Responsibility
The Chain of Responsibility pattern is used to process a request through a chain of handlers. Each handler decides either to process the request or to pass it to the next handler in the chain.

### Command Pattern
The Command pattern encapsulates a request as an object, thereby allowing for parameterization of clients with different requests, queuing of requests, and logging the requests.

### Facade Pattern
The Facade pattern provides a simplified interface to a complex subsystem. It offers a higher-level interface that makes the subsystem easier to use.

### Factory Pattern
The Factory pattern is used to create objects without specifying the exact class of object that will be created. It provides a way to encapsulate the instantiation logic.

### Iterator Pattern
The Iterator pattern provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

### Proxy Pattern
The Proxy pattern provides a surrogate or placeholder for another object to control access to it.

### Strategy Pattern
The Strategy pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. It lets the algorithm vary independently from clients that use it.

### Visitor Pattern
The Visitor pattern represents an operation to be performed on the elements of an object structure. It allows you to define a new operation without changing the classes of the elements on which it operates.
