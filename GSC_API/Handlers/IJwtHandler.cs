using GSC_API.Dto;

namespace GSC_API.Handlers
{
    public interface IJwtHandler
    {
        string GenerateToken(UserDto user, IEnumerable<string> roles);
    }
}
