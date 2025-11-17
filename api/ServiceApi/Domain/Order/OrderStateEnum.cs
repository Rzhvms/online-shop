namespace Domain.Order;

/// <summary>
/// Перечисление состояний заказа
/// </summary>
public enum OrderStateEnum
{
    /// <summary>
    /// Заказ создан
    /// </summary>
    Created = 0,
    
    /// <summary>
    /// Заказ подтвержден
    /// </summary>
    Confirmed = 1,
    
    /// <summary>
    /// На сборке
    /// </summary>
    Assembling = 2,
    
    /// <summary>
    /// Собран
    /// </summary>
    Assembled = 3,
    
    /// <summary>
    /// Ожидает курьера
    /// </summary>
    AwaitingCourier = 4,
    
    /// <summary>
    /// Передан курьеру
    /// </summary>
    HandedToCourier = 5,
    
    /// <summary>
    /// В пути
    /// </summary>
    OnTheWay = 6,
    
    /// <summary>
    /// Доставлен
    /// </summary>
    Delivered = 7,
    
    /// <summary>
    /// Отменен
    /// </summary>
    Cancelled = 8,
    
    /// <summary>
    /// Иное, для возможного расширения
    /// </summary>
    Default = 9
}
