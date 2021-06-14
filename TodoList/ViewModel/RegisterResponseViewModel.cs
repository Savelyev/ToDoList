using System.Collections.Generic;

namespace TodoList.ViewModel
{
    public class RegisterResponseViewModel
    {
        public bool IsSuccessfulRegistration { get; set; }

        public string Token { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
