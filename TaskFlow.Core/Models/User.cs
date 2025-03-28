using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Core.Models
{
    public class User : IdentityUser
    {
        public User(string firstName, string lastName, ICollection<TaskModel> Tasks)
        {
            FirstName = firstName;
            LastName = lastName;
            Tasks = new List<TaskModel>();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public ICollection<TaskModel> Tasks { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
