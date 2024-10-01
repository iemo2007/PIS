using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PIS.API.Middleware;
using PIS.Application;
using PIS.DAL;
using PIS.Models;
using PIS.ViewModels.Resources;
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PISContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("PISNew")));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
          .AddRoles<IdentityRole>()
          .AddRoleManager<RoleManager<IdentityRole>>()
          .AddUserManager<UserManager<ApplicationUser>>()
          .AddSignInManager<SignInManager<ApplicationUser>>()
          .AddEntityFrameworkStores<PISContext>()
          .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.SignIn.RequireConfirmedEmail = false;
});


builder.Services.AddScoped<JWTService>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ScheduleManager>();
builder.Services.AddTransient<StationManager>();
builder.Services.AddTransient<TrainStatusManager>();
builder.Services.AddTransient<TrainDelayReasonManager>();
builder.Services.AddTransient<TrainScheduleManager>();
builder.Services.AddTransient<TrainTripManager>();

builder.Services.AddAuthentication(/*JwtBearerDefaults.AuthenticationScheme*/ x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true, // Ensure the token is not expired
            ValidateIssuerSigningKey = true,
                  
            //ClockSkew = TimeSpan.Zero // Optional: Set the clock skew to zero to avoid time mismatches
        };
    });

    builder.Services.AddAuthorization();

//builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
// app.UseMiddleware<ExceptionMiddleware>();
// app.UseMiddleware<StationClaimMiddleware>();
// app.UseStatusCodePagesWithReExecute("/api/errors/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
// app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
