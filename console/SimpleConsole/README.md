# SimpleConsole

- creates a simple console application that creates a Semantic Kernel client and runs a Chat Completion query.

## Getting Started

- set secrets in `SimpleConsole.csproj` using .NET User Secrets

  ```bash
  dotnet user-secrets init

  dotnet user-secrets set "AOAI:ModelId" "..."
  dotnet user-secrets set "AOAI:ApiKey" "..."
  dotnet user-secrets set "AOAI:Endpoint" "..."
  ```
