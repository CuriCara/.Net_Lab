namespace Service.Settings;

public static class FarmSettingsReader
{
    public static FarmSettings Read(IConfiguration configuration)
    {
        return new FarmSettings
        {
            FarmDbContextConnectionString = configuration.GetValue<string>("HotelChainDbContext"),
            IdentityServerUri = configuration.GetValue<string>("IdentityServer:Uri"),
            ClientId = configuration.GetValue<string>("IdentityServer:ClientId"),
            ClientSecret = configuration.GetValue<string>("IdentityServer:ClientSecret"),
            ApiName = configuration.GetValue<string>("IdentityServer:ApiName"),
            AdminData = new 
            (
                configuration.GetValue<string>("IdentityServer:AdminData:UserName"),
                configuration.GetValue<string>("IdentityServer:AdminData:Password")
                )
        };
    }
}