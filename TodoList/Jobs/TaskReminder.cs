using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TodoList.Jobs
{
    public class TaskReminder : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //await File.AppendAllLinesAsync("d:\\task_reminder.txt", new List<string> { DateTime.Now.ToString() });
        }
    }
}
