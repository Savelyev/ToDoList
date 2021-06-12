# ToDoList

Hi there! This's my test task for Mentalstack.

## Running and setups

* Please add appsettings.json with setups in the root directory (TodoList/appsettings.json):
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ApplicationContext": "Server={{CONNECTION_TO_YOUR_DB(example: (LocalDB)\\MSSQLLocalDB)}};Database={{YOUR_DB_NAME}};Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "JWTSettings": {
    "securityKey": "{{YOUR_SECURITY_KEY}}",
    "validIssuer": "{{YOUR_ISSUER (example: ToDoListAPI)}}",
    "validAudience": "{{YOUR_AUDIENCE (example: http://localhost:5011)}}",
    "expiryInMinutes": 5
  }
}
```
* Go to the `cd TodoList/ClientApp` and run `npm install`
