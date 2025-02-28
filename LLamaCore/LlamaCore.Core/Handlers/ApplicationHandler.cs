using Microsoft.Extensions.AI;
using System.Text;

namespace LlamaCore.Core.Handlers;

public static class ApplicationHandler
{
    public static async Task RunAsync(IChatClient client)
    {
        var chatHistory = new List<ChatMessage>();

        while (true)
        {
            Console.Write("Ask me anything: ");
            string? userPrompt = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userPrompt))
                return; // Skip empty input

            chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

            Console.Write("AI Response: ");
            var responseBuilder = new StringBuilder();

            await foreach (var item in client.GetStreamingResponseAsync(chatHistory))
            {
                Console.Write(item.Text);
                responseBuilder.Append(item.Text);
            }

            Console.WriteLine();
            chatHistory.Add(new ChatMessage(ChatRole.Assistant, responseBuilder.ToString()));
        }
    }
}
