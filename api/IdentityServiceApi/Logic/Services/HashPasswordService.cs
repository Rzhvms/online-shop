using System.Security.Cryptography;
using Logic.Services.Interfaces;

namespace Logic.Services;

/// <inheritdoc />
internal class HashPasswordService : IHashPasswordService
{
    /// <summary>
    /// Случайная строка, добавляемая к паролю перед хэшированием, 128 бит
    /// </summary>
    private const int SaltSize = 16;
    
    /// <summary>
    /// Ключ, 256 бит
    /// </summary>
    private const int KeySize = 32;
    
    /// <summary>
    /// Количество итераций PBKDF2
    /// </summary>
    private const int HashIterations = 10000;
    
    /// <inheritdoc />
    public Task<string> HashPassword(string password)
    {
        using var numberGenerator = RandomNumberGenerator.Create();
        var salt = new byte[SaltSize];
        numberGenerator.GetBytes(salt);
        
        using var deriveBytes = new Rfc2898DeriveBytes(password, salt, HashIterations, HashAlgorithmName.SHA256);
        var hash = deriveBytes.GetBytes(KeySize);

        var hashedPassword = $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        return Task.FromResult(hashedPassword);
    }
    
    /// <inheritdoc />
    public Task<bool> VerifyPassword(string password, string hashedPassword)
    {
        var hashedPasswordParts = hashedPassword.Split('.');
        
        if (hashedPasswordParts.Length != 2)
        {
            return Task.FromResult(false);
        }

        var salt = Convert.FromBase64String(hashedPasswordParts[0]);
        var storedHash = Convert.FromBase64String(hashedPasswordParts[1]);

        using var deriveBytes = new Rfc2898DeriveBytes(password, salt, HashIterations, HashAlgorithmName.SHA256);
        var computedHash = deriveBytes.GetBytes(KeySize);

        var isMatch = CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        return Task.FromResult(isMatch);
    }
}