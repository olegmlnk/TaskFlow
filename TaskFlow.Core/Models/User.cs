using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Core.Models
{
    public class User : IdentityUser
    {
        public User(string firstName, string lastName, List<TaskModel> Tasks)
        {
            FirstName = firstName;
            LastName = lastName;
            Tasks = new List<TaskModel>();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public List<TaskModel> Tasks { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public static (User User, string Error) Create(string firstName, string lastName, List<TaskModel> tasks)
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return (null, "First name and last name cannot be empty");
            }

            var user = new User(firstName, lastName, tasks);

            return (user, null);
        }
    }
}
