using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repository;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private ITaskRepository taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return taskRepository.GetList().OrderByDescending(x => x.DueDateTime);
        }

        [HttpGet("{id}")]
        public Task Get(Guid id)
        {
            return taskRepository.Get(id);
        }

        [HttpPost]
        public IActionResult Post(Task task)
        {
            if (ModelState.IsValid)
            {
                return Ok(taskRepository.Create(task));
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Task task)
        {
            if (ModelState.IsValid)
            {
                return Ok(taskRepository.Update(task));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(taskRepository.Delete(id));
        }
    }
}
