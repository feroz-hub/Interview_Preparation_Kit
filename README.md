# Interview Preparation Kit — Arrays & SOLID Principles (C#/.NET)

## Overview
This repository contains a collection of small, focused C# console applications for interview preparation:

- Array problem exercises grouped by difficulty (Basic, Intermediate)
- SOLID principles demonstrations under `Principles/SOLID`, including a Dependency Inversion Principle (DIP) sample that contrasts a proper DI-driven composition with an anti-pattern (tight coupling)

The solution is organized as multiple standalone console apps that can be run individually with the `dotnet` CLI.

## Tech Stack
- Language: C# (projects target `net10.0` as seen in `DIP.csproj`)
- Framework: .NET 10.0 (SDK-based projects)
- Package manager / build tool: `dotnet` CLI (NuGet for dependencies)
- Dependency Injection (where applicable): `Microsoft.Extensions.DependencyInjection`

## Requirements
- .NET SDK 10.0 (or a compatible preview/build that supports `net10.0`)
  - You can check your version with:
    - `dotnet --version`
- A C# IDE/editor is optional (e.g., JetBrains Rider, Visual Studio, VS Code).

## Getting Started
1. Clone the repository
   - `git clone <your-fork-or-repo-url>`
   - `cd Interview_Preparation_Kit`
2. Restore packages
   - `dotnet restore InterviewPreparation.sln`
3. Build all projects
   - `dotnet build InterviewPreparation.sln -c Release`

## Running Projects
This solution contains many small console apps. You can run any of them with `dotnet run --project <path-to-csproj>`.

Examples:

- Run a Basic array exercise (e.g., Largest Number in Array):
  - `dotnet run --project Basic/LargestNumberInArray/LargestNumberInArray.csproj`

- Run an Intermediate array exercise (e.g., Remove Duplicates):
  - `dotnet run --project Intermediate/RemoveDuplicates/RemoveDuplicates.csproj`

- Run the SOLID — DIP demo:
  - `dotnet run --project Principles/SOLID/DIP/DIP.csproj`
  - The DIP demo supports choosing a logger via CLI arg or environment variable (see “Environment Variables”). It also prints an anti-pattern example to contrast tight coupling.

### SOLID/DIP Demo Notes
- Composition root: `Principles/SOLID/DIP/Program.cs`
- Dependency wiring: `Principles/SOLID/DIP/Infrastructure/Registration/ServiceCollectionExtensions.cs`
- Switch logger implementation:
  - CLI argument: `dotnet run --project Principles/SOLID/DIP/DIP.csproj -- db`
  - or: `dotnet run --project Principles/SOLID/DIP/DIP.csproj -- file`
  - Environment variable: `LOGGER_TYPE=db` or `LOGGER_TYPE=file`
- Anti-pattern (for contrast): `Principles/SOLID/DIP/AntiPatterns/TightlyCoupled/BadDataAccessLayer.cs` is hard-wired to a specific logger.

## Scripts and Common Commands
There are no custom script files; use the `dotnet` CLI.

- Restore solution: `dotnet restore InterviewPreparation.sln`
- Build solution: `dotnet build InterviewPreparation.sln`
- Run a specific project: `dotnet run --project <path-to-csproj> [-- <args>]`

## Environment Variables
- `LOGGER_TYPE` (used by the SOLID/DIP demo)
  - Accepted values: `db` (default if not set) or `file`
  - Example:
    - macOS/Linux: `LOGGER_TYPE=file dotnet run --project Principles/SOLID/DIP/DIP.csproj`
    - Windows (PowerShell): `$env:LOGGER_TYPE='file'; dotnet run --project Principles/SOLID/DIP/DIP.csproj`

## Tests
At the time of writing, no test projects were detected in the repository.

TODO:
- Add unit tests (e.g., xUnit/NUnit/MSTest) for algorithmic exercises and SOLID demos.
- Integrate tests into CI (GitHub Actions/Azure DevOps) if applicable.

## Project Structure (high level)
```
Interview_Preparation_Kit/
├─ InterviewPreparation.sln                  # Solution including all console apps
├─ Basic/                                    # Entry-level array problems
│  ├─ AverageOfArray/
│  ├─ Count_Even_Odd_In_Array/
│  ├─ DifferenceBetweenMaxAndMin/
│  ├─ Frequency_Of_Number/
│  ├─ LargestNumberInArray/
│  ├─ LenghtOfArray/
│  ├─ ReverseArray/
│  ├─ SecondLargestNumberInArray/
│  ├─ SecondSmallestNumbetInArray/
│  └─ SmallestNumberInArray/
├─ Intermediate/                             # Intermediate array problems
│  ├─ DuplicateElementsInArray/
│  ├─ Merge2SortedArray/
│  ├─ RemoveDuplicates/
│  ├─ Rotate_Array_Left_Or_Right_By_K_Steps/
│  └─ UniqueElementsInArray/
└─ Principles/
   └─ SOLID/
      ├─ DIP/                                # Dependency Inversion Principle demo (console app)
      │  ├─ Application/Services/            # e.g., CustomerService
      │  ├─ Domain/                          # Interfaces and models
      │  ├─ Infrastructure/                  # Logging impls, repositories, DI registration
      │  ├─ AntiPatterns/TightlyCoupled/     # Bad examples (tight coupling)
      │  └─ Program.cs                       # Entry point
      ├─ ISP/                                # Interface Segregation Principle (project present)
      ├─ LSP/                                # Liskov Substitution Principle (project present)
      ├─ OCP/                                # Open-Closed Principle (if present)
      └─ SRP/                                # Single Responsibility Principle (if present)
```

Note: Not all SOLID subprojects may have complete demos yet in this snapshot; check each directory for details.

## Dependencies
- `Microsoft.Extensions.DependencyInjection` (used in the DIP project)

## License
No explicit license file was found.

TODO:
- Add a `LICENSE` file (e.g., MIT/Apache-2.0) to clarify usage and contributions.

## Contributing
Contributions are welcome. Please consider adding tests with any new features or fixes, and keep examples small and focused. Open an issue first if proposing larger structural changes.

## Troubleshooting
- If `dotnet run` fails, ensure the installed .NET SDK supports `net10.0`.
- On preview SDKs, you may need to enable preview features in your environment/IDE.