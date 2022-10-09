using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Venhancer.Crowd.Core.Confugiration;
using Venhancer.Crowd.Core.Models;
using Venhancer.Crowd.Core.Repository;
using Venhancer.Crowd.Core.Services;
using Venhancer.Crowd.Core.UniteOfWork;
using Venhancer.Crowd.Data;
using Venhancer.Crowd.Data.Repositories;
using Venhancer.Crowd.Service.Services;
using Venhancer.Crowd.Shared.Configuration;
using Venhancer.Crowd.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VBT_CLOUD_1"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("Venhancer.Crowd.Data");
    });
});

builder.Services.AddIdentity<UserApp, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
builder.Services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        IssuerSigningKey = SignService.GetSymetricSecurityKey(tokenOptions.SecurityKey),
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Venhancer.Crowd.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
