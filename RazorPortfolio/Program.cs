using RazorPortfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddRazorPages().WithRazorPagesRoot("/Content");
//builder.Services.AddRazorPages(options =>
//{
//    options.RootDirectory = "/Pages";
//    options.Conventions.AddPageRoute("/Courses", "");
//    options.Conventions.AddPageRoute("/Index", "/index.html");
//    options.Conventions.AddPageRoute("/About", "/about.html");
//    options.Conventions.AddPageRoute("/Courses", "/courses.html");
//    options.Conventions.AddPageRoute("/Projects", "/projects.html");
//    options.Conventions.AddPageRoute("/Contact", "/contact.html");
//});

builder.Services.AddScoped<ILuckyNumberService, LuckyNumberService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
