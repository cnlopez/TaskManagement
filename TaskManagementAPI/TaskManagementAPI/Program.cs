using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;
using TaskManagementAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TaskManagementAPI.Extensions;
using TaskManagementAPI.Endpoints;


var builder = WebApplication.CreateBuilder(args);

var secretKey = builder.Configuration.GetSection("Jwt").GetSection("Secret").Value;
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xh&dp%*bq&aue9@twzed(m1vl((kojx+mxilqgdr^%s(ndf#g&")),
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = "your_issuer",
            ValidAudience = "your_audience",
            ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 }
        };
    });


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Services and repos
builder.Services.RegisterBusiness(builder.Configuration);
builder.Services.RegisterExternalServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();  //For Controllers
//builder.Services.AddAuthorization();  //For minimal API
//builder.Services.AddEndpointsApiExplorer(); //For minimal API
//builder.Services.AddSwaggerGen(); //For minimal API
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            //policy.WithOrigins("https://localhost:7265") // Sets the frontend URL 
            policy.WithOrigins("https://taskmanagementui-cjh2g3guggdfgte2.brazilsouth-01.azurewebsites.net") // Sets the frontend URL 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();  //For Controllers API

//app.MapProjectEndpoints();  //For minimal API

app.Run();
