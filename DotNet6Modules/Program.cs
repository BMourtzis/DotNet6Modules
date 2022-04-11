using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using DotNet6Modules;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

builder.Services.RegisterModules();

var app = builder.Build();

Configure(app);

app.MapEndpoints();

app.Run();


static void ConfigureServices(IServiceCollection services, ConfigurationManager configurationManager)
{
    // Add services to the container.
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(configurationManager.GetSection("AzureAd"));
    services.AddAuthorization();

    //services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

static void Configure(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    //app.MapControllers();
}