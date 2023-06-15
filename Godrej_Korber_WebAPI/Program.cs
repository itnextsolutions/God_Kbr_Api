using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Godrej_Korber_DAL;
using Godrej_Korber_DAL.TataCummins;
using Serilog;
using Godrej_Korber_WebAPI.Controllers.Tata_Cummins;
using Godrej_Korber_WebAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


//Configuration Of Log Start

var configuration_1 = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var logFilePath = configuration_1["Logging:Serilog:WriteTo:0:Args:path"];

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration_1)
     .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Logging.AddSerilog();

builder.Services.AddScoped<StockCountDL>();
builder.Services.AddScoped<StoreRequestCancellationDL>();
builder.Services.AddScoped<PalletizationDL>();

//End

var ValidAudience = configuration_1["jwt:Audience"];
var ValidIssuer = configuration_1["jwt:Issuer"];
var Key = configuration_1["jwt:key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = ValidIssuer,
        ValidAudience = ValidAudience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))


    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllers();

//Start Getting The Connection String From app.settings and Pass to the Oracle helper(Cnfiguration)
var configuration = new ConfigurationBuilder()
    .SetBasePath(app.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

OracleHelper.Configure(configuration);
LoginController.Configure(configuration);
//End

app.Run();
