using Quartz;
using Quartz.Impl;

namespace TodoList.Jobs
{
    public class TaskSheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<TaskReminder>().Build();

            ITrigger trigger = TriggerBuilder.Create()  
                .WithIdentity("task_trigger", "task_group")     
                .StartNow()                            
                .WithSimpleSchedule(x => x            
                    .WithIntervalInMinutes(1)          
                    .RepeatForever())                   
                .Build();                              

            await scheduler.ScheduleJob(job, trigger);       
        }
    }
}
