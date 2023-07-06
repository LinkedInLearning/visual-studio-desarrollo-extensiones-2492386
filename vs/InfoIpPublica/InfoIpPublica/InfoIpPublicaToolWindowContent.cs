namespace InfoIpPublica;

using Microsoft.VisualStudio.Extensibility.UI;

/// <summary>
/// A remote user control to use as tool window UI content.
/// </summary>
internal class InfoIpPublicaToolWindowContent : RemoteUserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InfoIpPublicaToolWindowContent" /> class.
    /// </summary>
    public InfoIpPublicaToolWindowContent()
        : base(dataContext: new InfoIpPublicaToolWindowData())
    {
    }
}
