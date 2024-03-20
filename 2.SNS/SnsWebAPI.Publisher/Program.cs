using Amazon.SimpleNotificationService;
using SQSWebAPI.Publisher.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAmazonSimpleNotificationService, AmazonSimpleNotificationServiceClient>();
builder.Services.AddSingleton<SendMessage>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
