using Wizardworks.Demo.Core;
using Wizardworks.Demo.Core.Infrastructure.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWizardworksDemoCoreDependencies(builder.Configuration);

builder.Services.AddScoped<GlobalExceptionHandlingMiddleware>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(365);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
