using VetClinic_backend.Models;

namespace VetClinic_backend.Authentication
{
    public interface IAuthentication
    {
        string GenerateAuthenticationToken(User user);
    }
}
