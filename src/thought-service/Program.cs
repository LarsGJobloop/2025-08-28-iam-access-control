var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// TLS Certificates are slightly difficult to setup
// so we ignore them for now
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
