using MimeKit;
using VetClinic_backend.Models;

namespace VetClinic_backend.Factories
{
    public interface IEmailMessageFactory
    {
        MimeMessage CreateSendPasswordEmail(User user, string password, string senderEmail);
    }
}
