using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SamuraiApp.Data;
using SamuraiApp.Data.Helper;
using SamuraiApp.Data.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//EF Core
builder.Services.AddDbContext<SamuraiContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SamuraiConnection"))
.EnableSensitiveDataLogging());

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders().AddEntityFrameworkStores<SamuraiContext>();

//Inject Object Repository
builder.Services.AddScoped<ISamurai, SamuraiRepo>();
builder.Services.AddScoped<ISword, SwordRepo>();

//JWT
var AppSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(AppSettingSection);
var AppSetting = AppSettingSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(AppSetting.Secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false

        };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
