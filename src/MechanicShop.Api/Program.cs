using MechanicShop.Api.Components;
using MechanicShop.Infrastructure.Data;
using MechanicShop.Infrastructure.RealTime;

using Scalar.AspNetCore;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "MechanicShop API V1");

        options.EnableDeepLinking();
        options.DisplayRequestDuration();
        options.EnableFilter();
    });

    app.MapScalarApiReference();

    await app.InitialiseDatabaseAsync();

    app.UseWebAssemblyDebugging();
}
else
{
    app.UseHsts();
}

app.UseCoreMiddlewares(builder.Configuration);

app.Use(async (context, next) =>
{
    Console.WriteLine($"[REQ ENTRY] {context.Request.Method} {context.Request.Path}{context.Request.QueryString}");

    // change to the exact path you observed, e.g. "/api/auth/login"
    if (string.Equals(context.Request.Path, "/api/auth/login", StringComparison.OrdinalIgnoreCase))
    {
        // If a debugger is not attached, this will prompt to attach one.
        System.Diagnostics.Debugger.Launch();
        System.Diagnostics.Debugger.Break();
    }

    await next();
});

app.MapControllers();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>().AllowAnonymous()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MechanicShop.Client._Imports).Assembly);

app.MapHub<WorkOrderHub>("/hubs/workorders");

app.Run();