using Microsoft.AspNetCore.Http.Features;
using CDN.ITEGAMAX._4._0;
using CDN.ITEGAMAX._4._0.Middleware;

var builder = WebApplication.CreateBuilder(args);
//Store config settings in one object
builder.Configuration.GetSection("CUSTAPPSETTINGS").Bind(CLCustAppsettings.Instance);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();
// Add services for IFormFile
//builder.Services.AddSingleton<IFileProvider>(
//    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "FileDownloaded")));

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 2 * 1024 * 1024; // Limit to 2MB
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ApiKeyMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
