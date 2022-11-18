using Authorization.auth;

namespace Atuhorization.auth
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserModel userDto);
    }
}
