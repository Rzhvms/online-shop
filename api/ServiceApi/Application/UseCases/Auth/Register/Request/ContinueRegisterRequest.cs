using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.UseCases.Auth.CreateUser.Request;

/// <summary>
/// Входная модель завершения регистрации
/// </summary>
public record ContinueRegisterRequest
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    /// <summary>
    /// Имя
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; init; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(20)]
    [JsonPropertyName("phone")]
    public string Phone { get; init; }
    
    /// <summary>
    /// Пол
    /// </summary>
    [JsonPropertyName("gender")]
    public string Gender { get; init; }
}