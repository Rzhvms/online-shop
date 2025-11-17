namespace Domain.Payment;

/// <summary>
/// Способы оплаты
/// </summary>
public enum PaymentMethodEnum
{
    /// <summary>
    /// Банковская карта
    /// </summary>
    Card = 1,
    
    /// <summary>
    /// СБП
    /// </summary>
    Sbp = 2,
    
    /// <summary>
    /// Наличные
    /// </summary>
    Cash = 3,
    
    /// <summary>
    /// Перевод
    /// </summary>
    BankTransfer = 4,
    
    /// <summary>
    /// ApplePay
    /// </summary>
    ApplePay = 5,
    
    /// <summary>
    /// GooglePay
    /// </summary>
    GooglePay = 6
}