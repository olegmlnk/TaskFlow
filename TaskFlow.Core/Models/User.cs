using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Core.Models
{
    public class User : IdentityUser
    {
        public User(Guid id, string firstName, string lastName, string email, ICollection<TaskModel> Tasks)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Tasks = new List<TaskModel>();
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public ICollection<TaskModel> Tasks { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
