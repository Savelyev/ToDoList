using System.Text.RegularExpressions;

namespace TodoList.Models.Password.Validator
{
    public class NoWhitespaceValidator : AbstractRegexValidator, IValidator
    {
        public new string Validate(string password)
        {
            if (Regex.IsMatch(password, GetRegex()))
            {
                return GetErrorMessage();
            }
            return null;
        }

        protected override string GetErrorMessage()
        {
            return "Passwords must not have at least any whitespace character.";
        }

        protected override string GetRegex()
        {
            return "\\s";
        }
    }
}
