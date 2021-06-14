using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repository;

namespace TodoList.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private ITaskRepository taskRepository;
        private UserManager<User> userManager;

        public TaskController(ITaskRepository taskRepository, UserManager<User> userManager)
        {
            this.taskRepository = taskRepository;
            this.userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return taskRepository.GetList(getUserId());
        }

        [HttpGet("{id}")]
        public Task Get(Guid id)
        {
            return taskRepository.Get(id, getUserId());
        }

        [HttpPost]
        public IActionResult Post(Task task)
        {
            if (ModelState.IsValid)
            {
                return Ok(taskRepository.Create(task, getUserId()));
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Task task)
        {
            if (ModelState.IsValid)
            {
                return Ok(taskRepository.Update(task, getUserId()));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(taskRepository.Delete(id, getUserId()));
        }

        private string getUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
            //return userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result.Id;
        }
    }
}
