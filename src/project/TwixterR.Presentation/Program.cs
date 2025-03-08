using TwixterR.Persistence.Extensions;
using TwixterR.Presentation.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPresentationServices();
builder.Services.AddPersistenceServices(builder.Configuration);


var app = builder.Build();
app.AddPresentationApp();


