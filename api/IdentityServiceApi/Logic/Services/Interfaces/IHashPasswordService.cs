namespace Logic.Services.Interfaces;

/// <summary>
/// Сервис для хэширования пароля по алгоритму Rfc2898DeriveBytes
/// </summary>
public interface IHashPasswordService
{
    /// <summary>
    /// Хэширование пароля
    /// </summary>
    Task<string> HashPassword(string password);

    /// <summary>
    /// Проверка пароля
    /// </summary>
    Task<bool> VerifyPassword(string password, string hashedPassword);
}