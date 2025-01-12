using DnnAspire.UserPreferences.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<AppDbContext>("userPreferencesDb");

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddUserPreferencesServices();

builder.Services.AddSingleton<AppDbInitializer>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<AppDbInitializer>());

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapUserPreferencesEndpoints();

app.Run();

