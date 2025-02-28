using LlamaCore.Core.Handlers;
using LlamaCore.Extensions;
using LlamaCore.Settings;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;


var builder = Host.CreateApplicationBuilder();

var appSettings = builder.Configuration.Get<AppSettings>();

var options = new JsonSerializerOptions { WriteIndented = true };
Console.WriteLine(JsonSerializer.Serialize(appSettings, options));

// Add services to the contianer.
builder.Services.AddServices(appSettings);

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

await ApplicationHandler.RunAsync(chatClient);