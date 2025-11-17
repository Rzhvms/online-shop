namespace Domain.Payment;

/// <summary>
/// Статус оплаты
/// </summary>
public enum PaymentStatusEnum
{
    /// <summary>
    /// Платеж создан, но не оплачен
    /// </summary>
    Pending = 1,
    
    /// <summary>
    /// Деньги зарезервированы
    /// </summary>
    WaitingForCapture = 2,
    
    /// <summary>
    /// Платеж полностью оплачен
    /// </summary>
    Paid = 3,
    
    /// <summary>
    /// Ошибка оплаты
    /// </summary>
    Failed = 4,
    
    /// <summary>
    /// Платёж отменён
    /// </summary>
    Canceled = 5,
    
    /// <summary>
    /// Деньги возвращены
    /// </summary>
    Refunded = 6 
}