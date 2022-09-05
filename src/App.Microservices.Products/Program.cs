using App.Microservices.Framework.ConfigOptions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddServiceFramework(configuration);
builder.Services.AddDataStore(configuration);
builder.Services.AddProductModules();

builder.Services.AddControllers().AddFluentValidation(x => x.AutomaticValidationEnabled = false); ; ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseServiceFramework();
app.UseDataStore();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
