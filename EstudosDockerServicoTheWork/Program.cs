using EstudosDockerServicoTheWork;
using EstudosDockerServicoTheWork.Infra;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddDbContext<ContextDb>(options =>
                    options.UseSqlServer(
                    builder.Configuration.GetConnectionString(connection!)), ServiceLifetime.Scoped);

builder.Services.AddRegisterServices();

var host = builder.Build();

{
    var scope = host.Services.CreateScope();
    var dbConetx = scope.ServiceProvider.GetRequiredService<ContextDb>();
    dbConetx.Database.EnsureCreated();
}

host.Run();
