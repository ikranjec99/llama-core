using LlamaCore.Core.Configuration;

namespace LlamaCore.Settings;

public class OllamaConfigurationElement : IOllamaConfiguration
{
    public required string ModelId { get; set; }

    public required string Uri {  get; set; }
}
