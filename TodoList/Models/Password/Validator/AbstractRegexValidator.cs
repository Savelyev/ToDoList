using System.Text.RegularExpressions;

namespace TodoList.Models.Password.Validator
{
    abstract public class AbstractRegexValidator : IValidator
    {
        public string Validate(string password)
        {
            if (!Regex.IsMatch(password, GetRegex()))
            {
                return GetErrorMessage();
            }
            return null;
        }

        abstract protected string GetErrorMessage();

        abstract protected string GetRegex();
    }
}
