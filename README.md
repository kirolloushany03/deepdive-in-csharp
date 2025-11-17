# Deep Dive into C# – A Hands-On Implementation

### Mastering advanced C# concepts hands-on — from OOP & delegates to async programming, based on Dometrain’s "Deep Dive: C#" course.

![C#](https://img.shields.io/badge/C%23-14.0-blueviolet?style=for-the-badge&logo=c-sharp)
![.NET](https://img.shields.io/badge/.NET-10.0-blue?style=for-the-badge&logo=dotnet)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2025-5C2D91?style=for-the-badge&logo=visual-studio)

---

## 🚀 About This Project

This repository serves as my practical implementation and deep exploration of advanced C# topics. Rather than simply following along with Nick Cosentino’s excellent **Deep Dive: C#** course on Dometrain, I chose to write, experiment with, and document the code for each concept to solidify my understanding.

My goal with this project was to bridge the gap between theoretical knowledge and practical application—ensuring I can confidently use these advanced C# features in real-world scenarios.

---

## ⚡ Highlights

- Hands-on practice of advanced C# topics  
- Covers OOP, delegates, LINQ, async/await, threads, and more  
- Structured repo with multi-project examples  
- Clear, documented, and fully implemented from course exercises  

---

## ✨ Key Concepts Implemented

This project is a code-based journey through the course curriculum. Below are the key areas implemented:

> **Note:** Specific examples are commented in `Program.cs`. Uncomment the ones you want to run.

---

### 🧱 Section 2 & 3: Reference Types, Value Types & OOP

- **Classes vs. Structs:** Understanding reference vs. value types.  
- **Enums & Flags:** Practical usage, including bitwise flag operations.  
- **Records:** Using records for **immutable data transfer objects (DTOs)** with built-in equality.  
- **Interfaces:** Defining contracts for behavior and achieving **polymorphism**.  
- **Abstract Classes:** Creating base classes with shared and required members.  
- **Composition over Inheritance:** Comparing approaches and showing how **composition leads to more flexible and maintainable code**.  
- **Generics:** Writing flexible, type-safe code with **generics and constraints**.  
- **Tuples:** Using `ValueTuple` for lightweight data grouping and returning multiple values.  

---

### 🗃️ Section 4: Working With Binary and String Data

- **String & Byte Encoding:** Converting between `string` and `byte[]` using ASCII & UTF-8.  
- **Streams:** Working with `MemoryStream` for handling binary data.  
- **File I/O:** Reading and writing files using `FileStream` for fine-grained control.  
- **IDisposable & `using`:** Ensuring **proper resource cleanup** for unmanaged resources.  
- **Serialization (XML & JSON):** Parsing XML and using **`System.Text.Json`** for object serialization.  

---

### ⚙️ Section 5: Advancing with Methods and Functions

- **Delegates (`Action`, `Func`, `Predicate`):** Using delegates to create type-safe **callbacks**.  
- **Extension Methods:** Adding new functionality to existing types.  
- **LINQ:** Applying functional query operations like **`Select`**, **`Where`**, and **`Average`**.  
- **`Lazy<T>`:** Deferring the creation of expensive objects until needed.  
- **Events:** Implementing the **publisher-subscriber pattern** for decoupled communication.  

---

### 🏗️ Section 6: Growing Code Bases

- **Multi-Project Solutions:** Structuring code with class libraries and consumer applications.  
- **`internal` & `InternalsVisibleTo`**: Making code **testable** without breaking encapsulation.  
- **NuGet Packages:** Referencing external libraries like Entity Framework Core.  

---

### ⚡ Section 7: Asynchronous, Parallel, and Multi-Threading

- **Threads:** Manually creating and managing threads.  
- **Tasks:** Using the Task Parallel Library (TPL) for robust async operations.  
- **`async` / `await`:** Writing **clean, non-blocking asynchronous code**.  
- **Cancellation Tokens:** Gracefully canceling long-running async operations.  

---

## 📂 Project Structure

```
.
├── DeepDive_In_C#/                     # Main project with organized examples
│   ├── Object-Oriented Programming/
│   ├── WorkingWithBinaryAndStringData/
│   ├── AdvancingWithMethodsAndFunctions/
│   └── AsynchronousParallelAndMultiThreading/
│
├── MultiProject.ClassLibrary/           # A .NET class library
└── MultiProject.Console/                # A console app that consumes the library
```

---

## 🛠️ How To Run

You will need the **.NET 10.0 SDK** (or a compatible preview version).

1. **Clone the repository:**
   ```sh
   git clone https://github.com/kirolloushany03/deepdive-in-csharp.git
   ```
2. **Navigate to the main project:**
   ```sh
   cd "./deepdive-in-csharp/DeepDive_In_C#"
   ```
3. **Run the application:**
   ```sh
   dotnet run
   ```
> **Note:** Uncomment the specific examples you wish to run inside `Program.cs`.

---

## 📚 Acknowledgments

This project was created as part of my learning journey through the  
**Deep Dive: C#** course by **Nick Cosentino** on Dometrain.  
All code in this repository represents my own implementations and practice exercises based on the course content.

---

## 🤝 Connect With Me

🔗 **LinkedIn:** [https://www.linkedin.com/in/kirolloushanna/](https://www.linkedin.com/in/kirolloushanna/)
