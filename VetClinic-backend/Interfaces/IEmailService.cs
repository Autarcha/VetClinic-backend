using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendPasswordMail(User user, string password);
    }
}
