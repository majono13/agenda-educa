using EducaApi.Infra.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Injeção de dependencia do IoC
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

//Remove retornos nulos
builder.Services.AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

//Autenticação

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser().Build());
});

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kjdf2i235wqiuyasjh1o387465kqw219jKJtRERsoihoeftrqscjlqd"));
builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer("Bearer", options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = key,
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //Cors
    app.UseCors(policy => policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetIsOriginAllowed(origin => true)
                                .AllowCredentials());
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
