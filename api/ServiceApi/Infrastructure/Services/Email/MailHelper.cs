using Infrastructure.Services.Email.Interfaces;
using Infrastructure.Services.Email.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services.Email;

/// <inheritdoc />
internal class MailHelper : IMailHelper
{
    private static EmailSettings _settings;

    private MailHelper(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }

    /// <inheritdoc />
    public MimeMessage CreateMimeMessage(string email, string subject, string message,
        string? recipientName = null)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_settings.FromName, _settings.FromAddress));
        emailMessage.To.Add(new MailboxAddress(recipientName ?? _settings.RecipientName, email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("html") { Text = message };

        return emailMessage;
    }
    
}