using MailKit.Net.Smtp;
using VetClinic_backend.Factories;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Services
{
    public class EmailService: IEmailService
    {
        private readonly IEmailMessageFactory _messageFactory;
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _senderMailAddress;
        private readonly string _senderPassword;
        private readonly string _senderUsername;

        public EmailService(IConfiguration configuration, IEmailMessageFactory messageFactory)
        {
            _messageFactory = messageFactory;
            var smtp = configuration.GetSection("Smtp");
            _smtpHost = smtp["host"];
            _senderMailAddress = smtp["address"];
            _smtpPort = Convert.ToInt32(smtp["port"]);
            _senderPassword = smtp["password"];
            _senderUsername = smtp["login"];
        }
        public async Task<bool> SendPasswordMail(User user, string password)
        {
            var message = _messageFactory.CreateSendPasswordEmail(user, password, _senderMailAddress);
            using var client = new SmtpClient();
            await client.ConnectAsync(_smtpHost, _smtpPort, true);
            await client.AuthenticateAsync(_senderUsername, _senderPassword);
            var response = await client.SendAsync(message);
            await client.DisconnectAsync(true);
            return true;
        }
    }
}
