using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Hello, Semantic Kernel!");
Console.ResetColor();

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var modelId = configuration["OpenAI:ModelId"];
var endpoint = configuration["OpenAI:Endpoint"];
var apiKey = configuration["OpenAI:ApiKey"];

var kernel = Kernel.CreateBuilder();



kernel.Build();


