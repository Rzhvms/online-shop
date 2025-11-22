namespace Application.Ports.Services.Email;

/// <summary>
/// Сервис работы с Email
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Отправить письмо
    /// </summary>
    /// <param name="email">Почта, куда мы отправляем</param>
    /// <param name="subject">Тема письма</param>
    /// <param name="message">Текст письма</param>
    Task SendEmailAsync(string email, string subject, string message);
    
}