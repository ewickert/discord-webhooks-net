namespace discordwebhooksnet;

public class DiscordClient
{
    private readonly string _url;
    private readonly string _appName;
    private readonly Dictionary<string, string> _fields = new();
    private readonly HttpClient _http;
    public DiscordClient(string appName, string webhookUrl): this(new HttpClient(), appName, webhookUrl) { }
    public DiscordClient(HttpClient client, string appName, string webhookUrl)
    {
        _http = client;
        _appName = appName;
        _url = webhookUrl;
        _fields.Add("username", appName);
    }

    public async void SendMessageAsync(string message)
    {
        _fields["content"] = message;
        var msg = new FormUrlEncodedContent(_fields);
        await _http.PostAsync(_url, msg);
    }
}
