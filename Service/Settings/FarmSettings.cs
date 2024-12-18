namespace Service.Settings;

public class FarmSettings
{
    public string? FarmDbContextConnectionString { get; set; }
    public string IdentityServerUri { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string ApiName { get; set; }
    public (string UserName, string Password) AdminData { get; set; }
}