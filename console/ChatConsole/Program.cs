using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

internal class Program
{
    private static async Task Main(string[] args)
    {
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
        var chatHistory = new ChatHistory();

        string? userInput;

        do
        {
            Console.Write("User > ");
            userInput = Console.ReadLine();
            chatHistory.AddUserMessage(userInput);

            var result = await chatCompletionService.GetChatMessageContentAsync(chatHistory);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Assistant > " + result);
            Console.ResetColor();
            chatHistory.AddAssistantMessage(result.Content);

        } while (userInput != null);


    }
}