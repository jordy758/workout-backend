using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Workout.Application.Common.Interfaces.Authentication;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Application.Common.Interfaces.Services;
using Workout.Infrastructure.Authentication;
using Workout.Infrastructure.Persistence;
using Workout.Infrastructure.Persistence.Repositories;
using Workout.Infrastructure.Services;

namespace Workout.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddAuth(configuration);
        services.AddPersistence(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var mySqlSettings = new MySqlSettings();
        configuration.Bind(MySqlSettings.SectionName, mySqlSettings);
        services.AddSingleton(Options.Create(mySqlSettings));

        var connectionString = mySqlSettings.ConnectionString;
        var mySqlVersion = ServerVersion.AutoDetect(connectionString);
        
        services.AddDbContext<WorkoutDbContext>(options => 
            options.UseMySql(connectionString, mySqlVersion));

        services.AddHealthChecks()
            .AddDbContextCheck<WorkoutDbContext>();

        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IWorkoutPlanRepository, WorkoutPlanRepository>()
            .AddScoped<IExerciseRepository, ExerciseRepository>();
    }
    
    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });
        return services;
    }
}