# Chat Console

- creates a console application that creates a Semantic Kernel client and runs chat dialog between the user and Azure OpenAI.

## Getting Started

- set secrets in `ChatConsole.csproj` using .NET User Secrets

  ```bash
  dotnet user-secrets init

  dotnet user-secrets set "AOAI:ModelId" "..."
  dotnet user-secrets set "AOAI:ApiKey" "..."
  dotnet user-secrets set "AOAI:Endpoint" "..."
  ```

