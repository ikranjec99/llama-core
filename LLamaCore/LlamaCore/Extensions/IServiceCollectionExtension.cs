using LlamaCore.Core.Configuration;
using LlamaCore.Settings;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;

namespace LlamaCore.Extensions;

public static class IServiceCollectionExtension
{
    private static IServiceCollection AddChatClient(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddChatClient(
            new OllamaChatClient(
                new Uri(appSettings.Ollama.Uri),
                appSettings.Ollama.ModelId
            )
        );

        return services;
    }

    private static IServiceCollection AddSettings(this IServiceCollection services, AppSettings appSettings)
    {

        appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));

        services.AddSingleton<IOllamaConfiguration>(appSettings.Ollama);

        return services;
    }

    public static void AddServices(this IServiceCollection services, AppSettings appSettings) =>
        services
            .AddSettings(appSettings)
            .AddChatClient(appSettings);

}
