# MethodAssessment Solution
## Overview
Create a new csproject that includes a controller endpoint to request the results of Problem 3
Ensure it has the following requirements:
One endpoint for the fixed size of 1000
One endpoint that allows you to pass a parameter for dynamic page size
One endpoint that implements paging. (get by page number, including dynamic page size)
Unit tests
Uses best programming practices
Include any additional optimizations or performance improvements for credit

Problem 3

Please think of the most efficient and deterministic way to produce an array of 1000 strings, each only 3 characters in length and all being unique values (no duplicated strings in the array, but duplicated characters in each string is OK)
## Prerequisites
To run, build, or modify the solution, ensure you have:

- **.NET 9 SDK** installed on your system.
- A compatible editor, such as JetBrains Rider or Visual Studio 2022+.
- Basic knowledge of ASP.NET Core, Razor, and C#.

## Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/idesai1210/method-assessment.git
   ```
2. Navigate to the solution directory:
   ```bash
   cd MethodAssessment
   ```
3. Restore the necessary packages:
   ```bash
   dotnet restore
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Access the application in your browser at `http://localhost:8080`.

6. To run tests, Navigate to the test solution directory:
   ```bash
   cd MethodAssessment.Test
   ```
7. Restore the necessary packages:
   ```bash
   dotnet restore
   ```
8. Run the Test:
   ```bash
   dotnet test
   ```
   
9. You can see swagger in your browser at: `http://localhost:8080/swagger`