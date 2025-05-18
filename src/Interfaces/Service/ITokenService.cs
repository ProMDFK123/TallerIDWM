using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user, string role);
    }
}
