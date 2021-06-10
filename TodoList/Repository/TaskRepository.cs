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

        public IEnumerable<Task> GetList()
        {
            return applicationContext.Tasks.ToList();
        }

        public Task Get(Guid id)
        {
            return applicationContext.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public Task Create(Task task)
        {
            try
            {
                applicationContext.Tasks.Add(task);
                applicationContext.SaveChanges();
            } 
            catch (Exception)
            {
            }
            return task;
        }

        public Task Update(Task task)
        {
            try
            {
                applicationContext.Update(task);
                applicationContext.SaveChanges();
            }
            catch (Exception)
            {
            }
            return task;
        }

        public Task Delete(Guid id)
        {
            Task task = applicationContext.Tasks.FirstOrDefault(x => x.Id == id);
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
