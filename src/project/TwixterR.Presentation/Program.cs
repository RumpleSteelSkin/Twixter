using TwixterR.Application.Extensions;
using TwixterR.Application.Services.JwtServices;
using TwixterR.Persistence.Extensions;
using TwixterR.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPresentationServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
var app = builder.Build();
app.AddPresentationApp();