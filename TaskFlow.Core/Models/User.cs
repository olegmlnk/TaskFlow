using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Core.Models
{
    public class User : IdentityUser<long>
    {
        public User(string username, string passwordHash, string email, ICollection<TaskModel?> tasks = null)
        {
            UserName = username;
            PasswordHash = passwordHash;
            Email = email;  
            Tasks = tasks ?? new List<TaskModel>();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        public string FullName => $"{FirstName} {LastName}";

        public static (User User, string Error) Create(string username, string passwordHash, string email, ICollection<TaskModel> tasks)
        {
            if(string.IsNullOrEmpty(username))
            {
                return (null, "Username cannot be empty");
            }
            if (string.IsNullOrEmpty(passwordHash))
            {
                return (null, "Password cannot be empty");
            }
            if (string.IsNullOrEmpty(email))
            {
                return (null, "Email cannot be empty");
            }

            return (new User(username, passwordHash, email, tasks), string.Empty);
        }
    }
}
