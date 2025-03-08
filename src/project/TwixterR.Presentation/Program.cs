using TwixterR.Presentation.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationServices(builder.Configuration);

var app = builder.Build();

app.AddPresentationApp();


