using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MotherOfLearningGameWeb;
using Newtonsoft.Json;
using Orleans.Providers.MongoDB.Configuration;
using Orleans.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    siloBuilder.UseMongoDBClient("mongodb://localhost");
    siloBuilder.AddMongoDBGrainStorageAsDefault(storageOptions => { storageOptions.DatabaseName = "MotherOfLearn"; });
    siloBuilder.Services.AddSerializer(serializerBuilder =>
    {
        serializerBuilder.AddNewtonsoftJsonSerializer(
            isSupported: type => type.Namespace!.StartsWith("Dto"));
    });
});

builder.Services.AddCors(o => o.AddPolicy("AllowAll", corsBuilder =>
{
    corsBuilder
        .WithOrigins("*")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        var jwtKey = builder.Configuration.GetValue<string>("JwtKey")!;
        o.SecurityTokenValidators.Add(new JwtTokenValidator(jwtKey));
        o.TokenValidationParameters = JwtTokenValidator.TokenValidationParameters(jwtKey);
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", policy => policy.RequireRole("admin"));
});

builder.Services.Configure<JsonGrainStateSerializerOptions>(options =>
{
    options.ConfigureJsonSerializerSettings = settings =>
    {
        settings.NullValueHandling = NullValueHandling.Ignore;
        settings.DefaultValueHandling = DefaultValueHandling.Populate;
        settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
    };
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        BearerFormat = "JWT",
        Scheme = "bearer",
        Type = SecuritySchemeType.Http
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();