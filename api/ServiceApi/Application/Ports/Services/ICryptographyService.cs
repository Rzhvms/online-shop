namespace Application.Ports.Services;

/// <summary>
/// Сервис для криптографических операций (хэширование, генерация соли)
/// </summary>
public interface ICryptographyService
{
    /// <summary>
    /// Генерация случайной соли для хэширования пароля
    /// </summary>
    string GenerateSalt();

    /// <summary>
    /// Хэширование пароля с использованием соли
    /// </summary>
    string HashPassword(string password, string salt);
}