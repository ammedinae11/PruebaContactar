using Asp.Versioning.ApiExplorer;
using Business;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WS.PruebaContactar.Modules.Authentication;
using WS.PruebaContactar.Modules.swagger;
using WS.PruebaContactar.Modules.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddSwaggerGen();
builder.Services.AddVersioning();

//Authentication
builder.Services.AddAuthenticationExtensions(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebService API");
    //c.RoutePrefix = string.Empty;
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    for (int i = 0; i < provider.ApiVersionDescriptions.Count; i++)
    {
        ApiVersionDescription? description = provider.ApiVersionDescriptions[i];
        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
