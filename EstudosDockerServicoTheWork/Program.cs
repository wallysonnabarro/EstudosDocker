using EstudosDockerServicoTheWork;
using EstudosDockerServicoTheWork.Infra;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddRegisterServices();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var dbConetx = scope.ServiceProvider.GetRequiredService<ContextDb>();
    dbConetx.Database.EnsureCreated();
}

host.Run();
