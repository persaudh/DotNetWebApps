using AspDotNetCoreMVC.Data;
using AspDotNetCoreMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ILocalizedText, LocalizedText>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// (/) => HomeController:Index
// /developer => DeveloperController:Index
// /shop/product/4 => ShopController:Product(4)

// reserved keywords: cntroller, action, area, handler, page
app.MapControllerRoute(
    name: "news",
    pattern: "news/{*article}",
    defaults: new { controller = "News", action = "Atricle" });
// Other Routes before default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
