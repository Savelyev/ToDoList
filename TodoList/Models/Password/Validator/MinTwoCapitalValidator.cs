namespace TodoList.Models.Password.Validator
{
    public class MinTwoCapitalValidator : AbstractRegexValidator, IValidator
    {
        protected override string GetErrorMessage()
        {
            return "Passwords must not have at least min 2 capital characters.";
        }

        protected override string GetRegex()
        {
            return "^(?=(?:.*?[A-Z]){2})"; // If honest without internet I would use something like ".*[A-Z].*[A-Z].*"
        }
    }
}
