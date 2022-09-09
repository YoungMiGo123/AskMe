using AskMe.Core.Core.Models.Interfaces;
using AskMe.Core.Core.Models.Models;
using AskMe.Core.Core.Settings.Interfaces;
using AskMe.Core.Core.Settings.Models;
using AskMe.Services.Services.Models.Interfaces;
using AskMe.Services.Services.Models.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json")
     .Build();
var openAiSettings = configuration.GetSection("OpenAiSettings")
    .Get<OpenAiSettings>();

builder.Services.AddSingleton<IOpenAISettings>(x => openAiSettings);
builder.Services.AddSingleton<ISearchEngine, OpenAiSearchEngine>();
builder.Services.AddSingleton<IApplicationLogger, ApplicationLogger>();
builder.Services.AddSingleton<IHttpService, HttpService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
