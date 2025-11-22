using Application.Ports.Services.Email;
using Infrastructure.Services.Email.Interfaces;
using MailKit.Net.Smtp;

namespace Infrastructure.Services.Email;

/// <inheritdoc />
public class EmailService : IEmailService
{
    private readonly IEmailClient _client;
    private readonly IMailHelper _mailHelper;

    public EmailService(IEmailClient smtpClient, IMailHelper mailHelper)
    {
        _client = smtpClient;
        _mailHelper = mailHelper;
    }


    /// <inheritdoc />
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailMessage = _mailHelper.CreateMimeMessage(email, subject, message);
        await _client.SendAsync(emailMessage);
    }
}