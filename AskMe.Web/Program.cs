using AskMe.Core.Core.Settings.Interfaces;
using AskMe.Core.Core.Settings.Models;
using AskMe.Services.Services.Models.Interfaces;
using AskMe.Services.Services.Models.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json")
     .Build();

var askMeSettings = configuration.GetSection("AskMeSettings")
    .Get<AskMeSettings>();

builder.Services.AddSingleton<IAskMeSettings>(x => askMeSettings);
builder.Services.AddSingleton<IResponseProcessor, ResponseProcessor>();
builder.Services.AddSingleton<IApplicationLogger, ApplicationLogger>();
builder.Services.AddSingleton<IHttpService, HttpService>();
builder.Services.AddSingleton<IAskMeServiceAdapter, AskMeServiceAdapter>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/AskMe/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AskMe}/{action=Index}/{id?}");

app.Run();
