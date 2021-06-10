using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TodoList.Models
{
    public class User : IdentityUser
    {
        public List<Task> Tasks { get; set; }
    }
}
