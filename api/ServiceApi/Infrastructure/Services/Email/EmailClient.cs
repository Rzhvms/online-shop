using Infrastructure.Services.Email.Interfaces;
using Infrastructure.Services.Email.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services.Email;

/// <inheritdoc />
public class EmailClient : IEmailClient
{
    private readonly EmailSettings _settings;
    
    public EmailClient(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }

    /// <inheritdoc />
    public async Task SendAsync(MimeMessage message)
    {
        using var client = new SmtpClient();

        await client.ConnectAsync(_settings.Host, _settings.Port, _settings.UseSsl);
        await client.AuthenticateAsync(_settings.Username, _settings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}

