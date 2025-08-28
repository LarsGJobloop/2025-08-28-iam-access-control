using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwtOptions =>
    {
        // Who have issued the token (your OIDC provider)
        jwtOptions.Authority = "oidc.jobloop.com";
        // Your application usually (the site the app is hosted under)
        jwtOptions.Audience = "localhost";
    });

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
