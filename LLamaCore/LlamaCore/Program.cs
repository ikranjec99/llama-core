using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

const string ollamaUri = "http://localhost:11434";
const string ollamaModelId = "llama3";

builder.Services.AddChatClient(
    new OllamaChatClient(new Uri(ollamaUri), ollamaModelId)
);

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

// Start the conversation with context for the AI model
List<ChatMessage> chatHistory = new();

while (true)
{
    // Get user prompt and add to chat history
    Console.WriteLine("Your prompt:");
    var userPrompt = Console.ReadLine();
    chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

    // Stream the AI response and add to chat history
    Console.WriteLine("AI Response:");
    var response = "";
    await foreach (var item in
        chatClient.GetStreamingResponseAsync(chatHistory))
    {
        Console.Write(item.Text);
        response += item.Text;
    }
    chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
    Console.WriteLine();
}