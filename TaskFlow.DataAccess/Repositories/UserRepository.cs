using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;
using TaskFlow.DataAccess.Data;
using TaskFlow.DataAccess.Entities;

namespace TaskFlow.DataAccess.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("User not found");

            return _mapper.Map<User>(userEntity);
        }

        public async Task AddUser(User user)
        {
            var userEntity = new UserEntity
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Tasks = user.Tasks.Select(t => new TaskEntity
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    UserId = user.Id
                }).ToList()
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<long> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
