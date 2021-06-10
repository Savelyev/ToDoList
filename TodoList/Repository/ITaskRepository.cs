using System;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Repository
{
    public interface ITaskRepository
    {
        public IEnumerable<Task> GetList();

        public Task Get(Guid id);

        public Task Create(Task task);

        public Task Update(Task task);

        public Task Delete(Guid id);
    }
}
