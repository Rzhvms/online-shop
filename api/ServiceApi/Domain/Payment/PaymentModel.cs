namespace Domain.Payment;

/// <summary>
/// Модель платежа
/// </summary>
public record PaymentModel
{
    /// <summary>
    /// Идентификатор платежа
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; init; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Сумма платежа
    /// </summary>
    public decimal Amount { get; init; }
    
    /// <summary>
    /// Валюта
    /// </summary>
    public string Currency { get; init; }
    
    /// <summary>
    /// Способ оплаты
    /// </summary>
    public PaymentMethodEnum PaymentMethod { get; init; }
    
    /// <summary>
    /// Статус оплаты
    /// </summary>
    public PaymentStatusEnum Status { get; init; }
    
    /// <summary>
    /// ID транзакции в платёжной системе
    /// </summary>
    public string PaymentSystemId { get; init; }
    
    /// <summary>
    /// Ссылка на оплату
    /// </summary>
    public string PaymentUrl { get; init; }
    
    /// <summary>
    /// Был ли возврат
    /// </summary>
    public bool IsRefunded { get; init; }
    
    /// <summary>
    /// Сумма возврата
    /// </summary>
    public decimal RefundAmount { get; init; }
    
    /// <summary>
    /// Дата создания платежа
    /// </summary>
    public DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime UpdatedAt { get; init; }
}