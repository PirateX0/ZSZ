using Long.Utilities.Job;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Long.Utilities
{
    public static class QuartzHelper
    {
        public static void ScheduleByDate()
        {
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            IMutableTrigger triggerBossReport = CronScheduleBuilder.DailyAtHourAndMinute(16, 54).Build();//每天23:45执行一次
            triggerBossReport.Key = new TriggerKey("triggerTest");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
        }

        public static void ScheduleByInterval()
        {
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            {
                JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(BuildJob));

                var builder = CalendarIntervalScheduleBuilder.Create();
                builder.WithInterval(3, IntervalUnit.Second);
                IMutableTrigger triggerBossReport = builder.Build();
                triggerBossReport.Key = new TriggerKey("triggerTest");

                sched.ScheduleJob(jdBossReport, triggerBossReport);
                sched.Start();
            }
            {
                JobDetailImpl jdBossReport = new JobDetailImpl("jdTest2", typeof(KillJob));

                var builder = CalendarIntervalScheduleBuilder.Create();
                builder.WithInterval(3, IntervalUnit.Second);
                IMutableTrigger triggerBossReport = builder.Build();
                triggerBossReport.Key = new TriggerKey("triggerTest2");

                sched.ScheduleJob(jdBossReport, triggerBossReport);
                sched.Start();
            }
        }

        public static void ScheduleByInterval(params string[] jobs)
        {
            //IScheduler sched = new StdSchedulerFactory().GetScheduler();

            //问题：名字重复了jdBossReport
            //for (int i = 0; i < jobs.Length; i++)
            //{
            //    JobDetailImpl jdBossReport = new JobDetailImpl("job"+i, Type.GetType("Long.Utilities."+jobs[i]));
            //    var builder = CalendarIntervalScheduleBuilder.Create();
            //    builder.WithInterval(3, IntervalUnit.Second);
            //    IMutableTrigger triggerBossReport = builder.Build();
            //    triggerBossReport.Key = new TriggerKey("triggerTest");

            //    sched.ScheduleJob(jdBossReport, triggerBossReport);
            //}


            //sched.Start();
        }
    }

    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(context.Trigger.StartTimeUtc + " : excute job... ");
        }
    }
    public class TestJob2 : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(context.Trigger.StartTimeUtc + " : excute job2... ");
        }
    }
}
