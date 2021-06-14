using System;
using TodoList.Enum;

namespace TodoList.ViewModel
{
    public class TaskViewModel
    {
        private const string timeFormat = "HH:mm";
        private const string dateFormat = "MMM dd";

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueTime { get; set; }
        public string DueDate { get; set; }
        public string Priority { get; set; }
        public string NotificationPeriod { get; set; }

        public TaskViewModel(Models.Task task)
        {
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            DueTime = task.DueDateTime.ToString(timeFormat);
            DueDate = task.DueDateTime.ToString(dateFormat);
            Priority = task.Priority.ToString();
            NotificationPeriod = task.NotificationPeriod.ToString();
        }
    }
}
