namespace Service.IoC;

using Microsoft.EntityFrameworkCore;
using DataAccess;

public class DbContextConf
{
    
    public static void ConfigreService(WebApplicationBuilder builder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("D:\\RiderLab\\Farm\\Service\\appsettings.json", optional: false)
            .Build();
        string connectString = config.GetValue<string>("FarmDbContext");
        builder.Services.AddDbContextFactory<FarmDbContext>(options => { options.UseNpgsql(connectString); },
            ServiceLifetime.Scoped
        );
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<FarmDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}