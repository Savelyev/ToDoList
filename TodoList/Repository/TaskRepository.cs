using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Models;

namespace TodoList.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private ApplicationContext applicationContext;

        public TaskRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public IEnumerable<Task> GetList(string userId)
        {
            return applicationContext.Tasks
                .ToList()
                .OrderBy(x => x.DueDateTime)
                .Where(u => u.UserId == userId && u.IsActive);
        }

        public Task Get(Guid id, string userId)
        {
            return applicationContext.Tasks.FirstOrDefault(x => x.Id == id && x.UserId == userId);
        }

        public Task Create(Task task, string userId)
        {
            try
            {
                task.UserId = userId;
                task.IsActive = true;
                applicationContext.Tasks.Add(task);
                applicationContext.SaveChanges();
            } 
            catch (Exception)
            {
            }
            return task;
        }

        public Task Update(Task task, string userId)
        {
            try
            {
                if (task.UserId != userId)
                {
                    return task;
                }
                applicationContext.Update(task);
                applicationContext.SaveChanges();
            }
            catch (Exception)
            {
            }
            return task;
        }

        public Task Delete(Guid id, string userId)
        {
            Task task = applicationContext.Tasks.FirstOrDefault(x => x.Id == id && x.UserId == userId);
            try
            {
                if (task != null)
                {
                    applicationContext.Tasks.Remove(task);
                    applicationContext.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
            return task;
        }
    }
}
