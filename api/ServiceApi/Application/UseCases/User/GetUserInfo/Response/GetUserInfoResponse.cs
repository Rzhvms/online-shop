using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.User.GetUserInfo.Response;

/// <summary>
/// Выходная модель по получению базовой инфомрации о пользователе
/// </summary>
public record GetUserInfoResponse
{
    /// <summary>
    /// Электронная почта пользователя, используется для логина и уведомлений.
    /// </summary>
    public string? Email { get; init; }
    
    /// <summary>
    /// Номер телефона пользователя.
    /// </summary>
    public string? Phone { get; init; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    /// Дата создания пользователя.
    /// </summary>
    public DateTime? CreateAt { get; init; }
    
    /// <summary>
    /// Дата последнего обновления данных пользователя.
    /// </summary>
    public DateTime? UpdateAt { get; init; }
}