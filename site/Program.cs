using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using SITE.ITEGAMAX._4._0._2;
using SITE.ITEGAMAX._4._0._2.Middleware;
using SITE.ITEGAMAX._4._0._2.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetSection("CUSTAPPSETTINGS").Bind(CLCustAppsettings.Instance);
builder.Configuration.GetSection("COMPANYSETTINGS").Bind(CLCompanySettings.Instance);
builder.Configuration.GetSection("ConnectionStrings").Bind(CLConnectionStrings.Instance);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
     {
        new CultureInfo("en"),
        //new CultureInfo("de"),
        //new CultureInfo("fr"),
        //new CultureInfo("es"),
        //new CultureInfo("ru"),
        //new CultureInfo("ja"),
        //new CultureInfo("ar"),
        //new CultureInfo("zh"),
        //new CultureInfo("en-GB"),
        new CultureInfo("sv")
    };
    options.DefaultRequestCulture = new RequestCulture("sv");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    };
});


builder.Services.AddSingleton<IContentService>(new ContentService());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()!.Value;
app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=ChangeLanguage}/{id?}");

app.UseMiddleware<ContentMiddleware>();

app.Run();
