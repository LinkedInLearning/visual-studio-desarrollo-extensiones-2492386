namespace InfoIpPublica;

using Microsoft.VisualStudio.Extensibility.UI;
using System.Net.Http.Json;
using System.Runtime.Serialization;

/// <summary>
/// ViewModel for the InfoIpPublicaToolWindowContent remote user control.
/// </summary>
[DataContract]
internal class InfoIpPublicaToolWindowData : NotifyPropertyChangedObject
{
    private readonly HttpClient httpClient;

    public InfoIpPublicaToolWindowData()
    {
        httpClient = new HttpClient();

        HelloCommand = new AsyncCommand(async (parameter, cancellationToken) =>
        {
            var result = await httpClient
                .GetFromJsonAsync<Model.Rootobject>("https://ipwho.is", cancellationToken);
            Text = $"{result.ip}\n{result.connection.isp}";
        });
    }

    private string _name = string.Empty;
    [DataMember]
    public string Name
    {
        get => _name;
        set => SetProperty(ref this._name, value);
    }

    private string _text = string.Empty;
    [DataMember]
    public string Text
    {
        get => _text;
        set => SetProperty(ref this._text, value);
    }

    [DataMember]
    public AsyncCommand HelloCommand { get; }
}
