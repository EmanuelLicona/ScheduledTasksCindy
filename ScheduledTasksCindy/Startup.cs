using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using ScheduledTasksCindy.Controllers;
using ScheduledTasksCindy.Helpers;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(ScheduledTasksCindy.Startup))]

namespace ScheduledTasksCindy
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
            //.UseSqlServerStorage("tu_cadena_de_conexion", new SqlServerStorageOptions
            //{
            //    PrepareSchemaIfNecessary = true // Esta opción asegura que las tablas se creen automáticamente
            //});
            .UseInMemoryStorage();

            //var baseController = new BaseController();

            // Configura un trabajo recurrente que se ejecute cada 6 horas
            //RecurringJob.AddOrUpdate(() => baseController.EnviarCorreo(), "0 */6 * * *");
            RecurringJob.AddOrUpdate("email_empleados", () => BaseController.EnviarCorreo(), Cron.Minutely);

            // Configuración de reintentos
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3 });


            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer();

        }
    }
}
