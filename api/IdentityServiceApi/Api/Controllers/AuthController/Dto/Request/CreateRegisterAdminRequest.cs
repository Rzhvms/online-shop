using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.AuthController.Dto.Request;

public record CreateRegisterAdminRequest
{
    [Required(ErrorMessage = "Логин обязателен")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 50 символов")]
    public required string UserName { get; init; }
    
    [Required(ErrorMessage = "Пароль обязателен")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов")]
    public required string Password { get; init; }
    
    [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
    public string? Name { get; init; }
    
    [EmailAddress(ErrorMessage = "Некорректный формат email")]
    public string? Email { get; init; }
    
    [RegularExpression(@"^(\+7|8)?[\s\-]?\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$", 
        ErrorMessage = "Некорректный формат номера телефона")]
    public string? Phone { get; init; }
}