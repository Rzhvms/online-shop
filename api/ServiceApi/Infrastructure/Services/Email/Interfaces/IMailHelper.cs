using MimeKit;

namespace Infrastructure.Services.Email.Interfaces;

/// <summary>
/// Вспомогательные методы для работы с почтой
/// </summary>
public interface IMailHelper
{
    /// <summary>
    /// Создать сообщение 
    /// </summary>
    /// <param name="email">Почтп</param>
    /// <param name="subject">Тема письма</param>
    /// <param name="message">Сообщение</param>
    /// <param name="recipientName">Имя получателя</param>
    MimeMessage CreateMimeMessage(string email, string subject, string message,
        string? recipientName = null);
}