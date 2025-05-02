using Microsoft.AspNetCore.Mvc.Formatters;
using WorkoutTracker.Components;
using WorkoutTracker.Data.SeedData;
using WorkoutTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddScoped<IWorkoutTrackerDbService, WorkoutTrackerDbService>();
builder.Services.AddScoped<IWorkoutService,WorkoutService>();
builder.Services.AddScoped<IWorkoutPlanService, WorkoutPlanService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserPlanService, UserPlanService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

Seed.Initialize(app.Services);

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

app.Run();
