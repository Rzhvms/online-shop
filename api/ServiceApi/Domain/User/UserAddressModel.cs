namespace Domain.User;

/// <summary>
/// Модель с адресом пользователя
/// </summary>
public class UserAddressModel
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Страна
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Улица
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Номер дома
    /// </summary>
    public string? House { get; set; }

    /// <summary>
    /// Номер квартиры / офиса
    /// </summary>
    public string? Apartment { get; set; }
    
    /// <summary>
    /// Почтовый индекc
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// Используется ли адрес по умолчанию при оформлении заказа
    /// </summary>
    public bool IsDefault { get; set; } = false;
}