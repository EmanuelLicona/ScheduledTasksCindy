using Quartz.Impl;
using Quartz;

namespace ScheduledTasksCindy.Helpers
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = new StdSchedulerFactory().GetScheduler().Result;
            scheduler.Start().Wait();

            IJobDetail job = JobBuilder
                .Create<EmailEmployeesJob>()
                .WithIdentity("email_empleados")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(10)
                .RepeatForever()
            )
            .Build();

            //// Definir el primer trigger (8:00 AM)
            //ITrigger trigger1 = TriggerBuilder.Create()
            //    .WithIdentity("trigger1", "group1")
            //    .WithCronSchedule("0 0 8 * * ?") // Ejecuta a las 8:00 AM todos los días
            //    .ForJob(job)
            //    .Build();

            //// Definir el segundo trigger (4:00 PM)
            //ITrigger trigger2 = TriggerBuilder.Create()
            //    .WithIdentity("trigger2", "group1")
            //    .WithCronSchedule("0 0 16 * * ?") // Ejecuta a las 4:00 PM todos los días
            //    .ForJob(job)
            //    .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}