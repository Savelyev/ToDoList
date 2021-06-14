using System;
using TodoList.Enum;

namespace TodoList.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime DueDateTime { get; set; }
        public PriorityLevel Priority { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
