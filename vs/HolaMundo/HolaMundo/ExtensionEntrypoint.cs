namespace HolaMundo;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Extensibility;

/// <summary>
/// Extension entrypoint for the VisualStudio.Extensibility extension.
/// </summary>
[VisualStudioContribution]
internal class ExtensionEntrypoint : Extension
{
    /// <inheritdoc />
    protected override void InitializeServices(IServiceCollection serviceCollection)
    {
        base.InitializeServices(serviceCollection);
        serviceCollection.AddScoped<Mensajes>();
        // You can configure dependency injection here by adding services to the serviceCollection.
    }
}

public class Mensajes
{
    public string Saluda()
    {
        return "¡Hola, LinkedIn Learning!";
    }
}