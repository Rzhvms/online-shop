using MimeKit;

namespace Infrastructure.Services.Email.Interfaces;

/// <summary>
/// TODO
/// </summary>
public interface IEmailClient
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task SendAsync(MimeMessage message);
}