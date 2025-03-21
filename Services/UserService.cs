using CV_hantering_REST_API.Data;
using CV_hantering_REST_API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CV_hantering_REST_API.Services
{
    public class UserService(CVhanteringDBContext context)
    {
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var UserList = await context.Users.Select(u => new UserDTO
            {
                id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            }).ToListAsync();

            return UserList;
        }
    }
}
