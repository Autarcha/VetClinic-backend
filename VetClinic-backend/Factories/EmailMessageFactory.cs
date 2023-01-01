using MimeKit;
using VetClinic_backend.Models;

namespace VetClinic_backend.Factories
{
    public class EmailMessageFactory: IEmailMessageFactory
    {
        public MimeMessage CreateSendPasswordEmail(User user, string password, string senderEmail)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress($"{user.Name} {user.Surname}", user.Email));
            message.From.Add(new MailboxAddress("Klinika Weterynaryjna ANIMA", senderEmail));
            message.Subject = "Klinika Weterynaryjna ANIMA - dostęp do konta";
            message.Body = new TextPart("plain") { Text = $"Witaj w klinice weterynaryjnej ANIMA. Dziekuje za skorzystanie z naszych usług. Dane dostępowe do konta: email: {user.Email}  hasło: {password}" };
            return message;
        }
    }
}
