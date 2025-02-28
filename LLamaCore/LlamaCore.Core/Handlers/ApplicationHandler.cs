using Microsoft.Extensions.AI;

namespace LlamaCore.Core.Handlers;

public static class ApplicationHandler
{
    public async static Task Run(IChatClient client)
    {
        // Start the conversation with context for the AI model
        List<ChatMessage> chatHistory = new();

        while (true)
        {
            // Get user prompt and add to chat history
            Console.WriteLine("Your prompt:");
            string? userPrompt = Console.ReadLine();
            chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

            // Stream the AI response and add to chat history
            Console.WriteLine("AI Response:");
            string response = "";
            await foreach (var item in
                client.GetStreamingResponseAsync(chatHistory))
            {
                Console.Write(item.Text);
                response += item.Text;
            }
            chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
            Console.WriteLine();
        }
    }
}
