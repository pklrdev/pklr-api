using Pklr.Api.Integrations;
using Pklr.Api.Integrations.FileStore;
using Pklr.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var fileStoreOptions = builder.Configuration
    .GetSection("FileStore").Get<FileStoreOptions>();

if (fileStoreOptions == null)
{
    throw new Exception("File store options are missing or failed to deserialize");
}

builder.Services.AddIntegrations(fileStoreOptions);
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseAuthMiddleware();

app.MapControllers();

app.Run();