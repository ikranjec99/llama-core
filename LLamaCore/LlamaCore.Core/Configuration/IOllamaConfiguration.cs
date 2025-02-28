namespace LlamaCore.Core.Configuration;

public interface IOllamaConfiguration
{
    string ModelId { get; }

    string Uri { get; }
}
