using Amazon.S3;
using Customers.WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAmazonS3, AmazonS3Client>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
