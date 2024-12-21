using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

const string USER_MESSAGE = "What is the meaning of life, the universe, and everything?";

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Hello, Semantic Kernel!");
Console.ResetColor();

Console.WriteLine("Getting configuration...");
var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var modelId = configuration["AOAI:ModelId"]
    ?? throw new InvalidOperationException("ModelId is missing in the configuration. Set it in the user secrets.");
var endpoint = configuration["AOAI:Endpoint"]
    ?? throw new InvalidOperationException("Endpoint is missing in the configuration. Set it in the user secrets.");
var apiKey = configuration["AOAI:ApiKey"]
    ?? throw new InvalidOperationException("ApiKey is missing in the configuration. Set it in the user secrets.");

var builder = Kernel.CreateBuilder();

// Configure the kernel
builder.AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

// Add services
builder.Services.AddLogging(services =>
    services.AddConsole().SetMinimumLevel(LogLevel.Trace));

// build the kernel
var kernel = builder.Build();

var chatCompletionService = kernel.Services.GetRequiredService<IChatCompletionService>();

Console.WriteLine("Sending message to Azure OpenAI...");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine(USER_MESSAGE);
Console.ResetColor();

try
{
    var result = await chatCompletionService.GetChatMessageContentAsync(USER_MESSAGE);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine(result);
    Console.ResetColor();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Something went wrong: ${ex.Message}");
    Console.ResetColor();
}

Console.WriteLine("Finished.");

