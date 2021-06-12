namespace TodoList.ViewModel
{
    public class AuthResponseViewModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
