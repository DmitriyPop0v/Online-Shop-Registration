using Authorization.auth;

namespace Authorization.Repository
{
    public interface IUserRepository:IDisposable
    {
        public Task<UserModel?> GetUser(UserDto user);
        public Task InsertUser(UserModel user);
        public Task SaveAsync();
    }
}
