using Microsoft.AspNetCore.Identity;

namespace TaskFlow.DataAccess.Entities
{
    public class UserEntity : IdentityUser<long>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<TaskEntity>? Tasks { get; set; } 
    }
}
