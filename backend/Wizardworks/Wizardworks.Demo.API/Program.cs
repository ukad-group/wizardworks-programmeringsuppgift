using Wizardworks.Demo.Core;
using Wizardworks.Demo.Core.Infrastructure.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWizardworksDemoCoreDependencies(builder.Configuration);

builder.Services.AddScoped<GlobalExceptionHandlingMiddleware>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseWizardworksCORS(builder.Configuration);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
