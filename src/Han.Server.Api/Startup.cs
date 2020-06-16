using FluentMigrator.Runner;
using Han.Server.Api.Extensions;
using Han.Server.Business.Commands.Widgets.CreateWidget;
using Han.Server.Business.Queries.Widgets.GetWidget;
using Han.Server.Data.Repositories;
using Han.Server.Data.Repositories.Mysql;
using Han.Server.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Han.Server.Business.Commands.Widgets.UpdateWidget;

namespace Han.Server.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddFluentMigratorCore()
                .ConfigureRunner
                (
                    builder => builder
                        .AddMySql5()
                        .WithGlobalConnectionString(ConfigurationProfile.SelectedDatabaseConnectionString)
                        .ScanIn(typeof(IRecord).Assembly).For.Migrations()
               );

            // Commands
            services.AddScoped<ICreateWidgetCommand, CreateWidgetCommand>();
            services.AddScoped<IUpdateWidgetCommand, UpdateWidgetCommand>();

            // Queries
            services.AddScoped<IGetWidgetQuery, GetWidgetQuery>();

            // Repositories
            services.AddScoped<IWidgetsRepository, WidgetsRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseHttpExceptionHandling();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Database.Create();
            Database.Migrate(migrationRunner);
        }
    }
}
