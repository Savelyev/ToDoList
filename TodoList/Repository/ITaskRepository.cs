using System;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Repository
{
    public interface ITaskRepository
    {
        public IEnumerable<Task> GetList(string userId);

        public Task Get(Guid id, string userId);

        public Task Create(Task task, string userId);

        public Task Update(Task task, string userId);

        public Task Delete(Guid id, string userId);
    }
}
