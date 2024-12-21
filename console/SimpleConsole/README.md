# SimpleConsole

- creates a simple console application that creates a Semantic Kernel client and runs a Chat Completion query.

## Getting Started

- set secrets in `SimpleConsole.csproj` using .NET User Secrets

  ```bash
  dotnet user-secrets init

  dotnet user-secrets set "OpenAI:ModelId" "..."
  dotnet user-secrets set "OpenAI:ChatModelId" "..."
  dotnet user-secrets set "OpenAI:EmbeddingModelId" "..."
  dotnet user-secrets set "OpenAI:ApiKey" "..."
  ```
