namespace HolaMundo;

using Microsoft;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using Microsoft.VisualStudio.Extensibility.Shell;
using System.Diagnostics;

/// <summary>
/// Command1 handler.
/// </summary>
[VisualStudioContribution]
internal class Command1 : Command
{
    private readonly TraceSource logger;
    private readonly Mensajes mensajes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Command1"/> class.
    /// </summary>
    /// <param name="extensibility">Extensibility object.</param>
    /// <param name="traceSource">Trace source instance to utilize.</param>
    public Command1(VisualStudioExtensibility extensibility, 
        TraceSource traceSource,
        Mensajes mensajes)
        : base(extensibility)
    {
        // This optional TraceSource can be used for logging in the command. You can use dependency injection to access
        // other services here as well.
        this.logger = Requires.NotNull(traceSource, nameof(traceSource));
        this.mensajes = mensajes;
    }

    /// <inheritdoc />
    public override CommandConfiguration CommandConfiguration => new("%HolaMundo.Command1.DisplayName%")
    {
        // Use this object initializer to set optional parameters for the command. The required parameter,
        // displayName, is set above. DisplayName is localized and references an entry in .vsextension\string-resources.json.
        Icon = new(ImageMoniker.KnownValues.RadarChart, IconSettings.IconAndText),
        Placements = new[] { CommandPlacement.KnownPlacements.ToolsMenu }
    };

    /// <inheritdoc />
    public override Task InitializeAsync(CancellationToken cancellationToken)
    {
        // Use InitializeAsync for any one-time setup or initialization.
        return base.InitializeAsync(cancellationToken);
    }

    /// <inheritdoc />
    public override async Task ExecuteCommandAsync(IClientContext context, 
        CancellationToken cancellationToken)
    {
        await context.ShowPromptAsync(mensajes.Saluda(), 
            PromptOptions.OK, 
            cancellationToken);
    }
}
