using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        ApplicationContext db;
        public TaskController(ApplicationContext context)
        {
            db = context;
            if (!db.Tasks.Any())
            {
                db.Tasks.Add(
                    new Task { Id = Guid.NewGuid(), Title = "first", Description = "first", DueDateTime = new DateTime(2021, 6, 10, 15, 45, 0), Priority = Enum.PriorityLevel.HighLevel }
                );
                db.Tasks.Add(
                    new Task { Id = Guid.NewGuid(), Title = "second", Description = "second", DueDateTime = new DateTime(2021, 6, 10, 16, 45, 0), Priority = Enum.PriorityLevel.MediumLevel }
                );
                db.Tasks.Add(
                    new Task { Id = Guid.NewGuid(), Title = "first", Description = "first", DueDateTime = new DateTime(2021, 6, 10, 15, 45, 0), Priority = Enum.PriorityLevel.NoLevel }
                );
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return db.Tasks.ToList();
        }

        [HttpGet("{id}")]
        public Task Get(Guid id)
        {
            return db.Tasks.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return Ok(task);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Update(task);
                db.SaveChanges();
                return Ok(task);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Task task = db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return Ok(task);
        }
    }
}
