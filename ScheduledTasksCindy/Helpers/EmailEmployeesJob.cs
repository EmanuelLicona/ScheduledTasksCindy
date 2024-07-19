using Quartz;
using ScheduledTasksCindy.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace ScheduledTasksCindy.Helpers
{
    public class EmailEmployeesJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                try
                {
                    BaseController.EnviarCorreo();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar el correo: " + ex.Message);
                }
            });
        }
    }
}