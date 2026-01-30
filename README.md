# TyreDataVisualiser C# Console App

This is a beginner-friendly C# console application project. It includes a simple Hello World example and instructions for getting started with C# development on Windows.

## Prerequisites
- **.NET SDK**: Download and install the latest .NET SDK from https://dotnet.microsoft.com/download
- **VS Code**: Recommended editor (https://code.visualstudio.com/)
- **C# Extension for VS Code**: Install the official C# extension from the VS Code marketplace for best experience.

## Getting Started
1. Open a terminal in this project folder.
2. Navigate to the `src` directory:
   ```
   cd src
   ```
3. Build the project:
   ```
   dotnet build
   ```
4. Run the project:
   ```
   dotnet run
   ```

## Project Structure
- `src/` - Contains the C# source code and project files.

## Project System Design
- Database: SQL database which stores TTC tyre data
- Backend: C# backend which is an API that calculates relevant metrics
- Frontend: vanilla typescript frontend with 
- Protocols: We use REST, as our primary protocol due to it's ease of use and pervasiveness

### Current to-dos
- Create script that transfers TTC data into SQL db
- Create new SQL schema that allows backend to interface with new data
- Design backend API that can easily interface with frontend with good error handling