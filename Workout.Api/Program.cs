using Workout.Api.Common.Errors;
using Workout.Application;
using Workout.Infrastructure;
using Workout.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddHealthChecks();

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddSingleton<ProblemDetailsFactory, WorkoutProblemDetailsFactory>();
}

var app = builder.Build();
{
    // Migrate latest database changes during startup
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider
            .GetRequiredService<WorkoutDbContext>();
    
        // Here is the migration executed
        dbContext.Database.Migrate();
    }
    
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseHealthChecks("/health");
    app.Run();
}
