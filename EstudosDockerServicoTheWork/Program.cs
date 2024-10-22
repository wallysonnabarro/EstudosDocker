using EstudosDockerServicoTheWork;
using EstudosDockerServicoTheWork.Infra;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<ContextDb>(
                       options =>
                       {
                           var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                           var password = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD");

                           if (string.IsNullOrEmpty(password))
                           {
                               throw new InvalidOperationException("Environment variable MSSQL_SA_PASSWORD is not set.");
                           }

                           connectionString = string.Format(connectionString!, password);

                           options.UseSqlServer(connectionString);

                       });

builder.Services.AddRegisterServices(builder.Configuration);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContextDb>();
    db.Database.Migrate();
}

host.Run();
