using Authorization.auth;
using Microsoft.EntityFrameworkCore;
using WebApiHotel.Data;

namespace Authorization.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserModel?> GetUser(UserDto user)
        {
            return await _dataContext.users.FirstOrDefaultAsync(u => u.Login == user.Login
                                                                      && u.Password == user.Password);
        }
        public async Task<UserModel?> GetUserLogin(UserModel user)
        {
            return await _dataContext.users.FirstOrDefaultAsync(u => u.Login == user.Login
                || u.Email == user.Email
                || u.mobile == user.mobile
                || u.UserName == user.UserName
            );
        }

        public async Task InsertUser(UserModel user)
        { 
            await _dataContext.users.AddAsync(user);
           
        }
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
