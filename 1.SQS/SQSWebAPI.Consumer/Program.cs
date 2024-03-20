using SQSWebAPI.Consumer;
using SQSWebAPI.Consumer.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ReceiveMessage>();

builder.Services.AddHostedService<BackgroundServiceForSQS>();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
