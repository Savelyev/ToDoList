using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TodoList.Models.Password.Validator;

namespace TodoList.Models.Password
{
    public class UserPasswordValidator : IPasswordValidator<User>
    {
        private List<IValidator> validators;

        public UserPasswordValidator(List<IValidator> validators)
        {
            this.validators = validators;
        }

        public System.Threading.Tasks.Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            foreach (var validator in validators)
            {
                var error = validator.Validate(password);
                if (string.IsNullOrEmpty(error))
                {
                    continue;
                }
                errors.Add(new IdentityError
                {
                    Description = error
                });
            }

            return System.Threading.Tasks.Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }


    }
}
