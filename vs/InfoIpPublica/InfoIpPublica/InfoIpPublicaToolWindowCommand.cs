namespace InfoIpPublica;

using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// A command for showing a tool window.
/// </summary>
[VisualStudioContribution]
public class InfoIpPublicaToolWindowCommand : Command
{
    /// <summary>InfoIpPublicaToolWindowCommand" /> class.
    /// </summary>
    /// <param name="extensibility">Extensibility object instance.</param>
    public InfoIpPublicaToolWindowCommand(VisualStudioExtensibility extensibility)
        : base(extensibility)
    {
    }

    /// <inheritdoc />
    public override CommandConfiguration CommandConfiguration => new(displayName: "Mostrar datos de IP pública")
    {
        // Use this object initializer to set optional parameters for the command. The required parameter,
        // displayName, is set above. To localize the displayName, add an entry in .vsextension\string-resources.json
        // and reference it here by passing "%InfoIpPublica.InfoIpPublicaToolWindowCommand.DisplayName%" as a constructor parameter.
        Placements = new[] { CommandPlacement.KnownPlacements.ExtensionsMenu },
        Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
    };

    /// <inheritdoc />
    public override async Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
    {
        await this.Extensibility.Shell().ShowToolWindowAsync<InfoIpPublicaToolWindow>(activate: true, cancellationToken);
    }
}
