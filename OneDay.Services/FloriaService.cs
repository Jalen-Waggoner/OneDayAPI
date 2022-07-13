using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OneDay.Services
{
    public class PostService : IFloriaService
    {
        private readonly ApplicationDbContext _context;
        public FloriaService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterUserAsync(UserFloria model)
        {
            if(await GetUserByEmailAsync(model.Email) !=null || await GetUserByUsernameAsync(model.Username) !=null)
            return false;

            var entity = new FloriaEntity
            {
                Email = model.Email,
                Username = model.Username,
                DateCreated = DateTime.Now
            };

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<FloriaDetail> GetUserByIdAsync (int userId)
        {
            var entity = await _context.Users.FindAsync(userId);
            if(entity is null)
                return null;
            
            var userDetail = new FloriaDetail
            {
                Id = entity.Id,
                Email = entity.Email,
                Username = entity.Username,
            };
            return userDetail;
        }
        public async Task<FloriaEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        private async Task<FloriaEntity> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
        }
    }

    
}