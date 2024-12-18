using Service.IoC;

var builder = WebApplication.CreateBuilder(args);

DbContextConf.ConfigureService(builder);
SerilogConf.ConfigureService(builder);
SwaggerConf.ConfigureServices(builder.Services);

var app = builder.Build();

SerilogConf.ConfigureApplication(app);
SwaggerConf.ConfigureApplication(app);
DbContextConf.ConfigureApplication(app);

app.UseHttpsRedirection();
app.Run();
