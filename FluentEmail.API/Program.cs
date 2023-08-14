using FluentEmail.API.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var emailSettings = builder.Configuration.GetSection("EmailSettings");
var defaultFromEmail = emailSettings["DefaultFromEmail"];
var host = emailSettings["SMTPSetting:Host"];
var port = emailSettings.GetValue<int>("Port");
var userName = emailSettings["UserName"];
var password = emailSettings["Password"];
builder.Services.AddFluentEmail(defaultFromEmail)
    .AddSmtpSender(host, port, userName, password);
builder.Services.AddScoped<IEmailService,EmailService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
