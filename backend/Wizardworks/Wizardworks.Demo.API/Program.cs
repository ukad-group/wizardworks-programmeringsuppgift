using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Wizardworks.Demo.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWizardworksDemoCoreDependencies(builder.Configuration);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(365);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
