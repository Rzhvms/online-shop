using Application.Enums;
using Application.Ports.Repositories;
using Application.Ports.Services;
using Application.UseCases.Auth.CreateUser.Request;
using Application.UseCases.Auth.CreateUser.Response;
using Domain.User;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Auth.CreateUser;

/// <inheritdoc />
public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly ILogger<CreateUserUseCase> _logger;
    private readonly IAuthTokenService _authTokenService;
    private readonly IAuthRepository _authRepository;
    private readonly ICryptographyService _cryptographyService;

    public CreateUserUseCase(
        ILogger<CreateUserUseCase> logger,
        IAuthTokenService authTokenService,
        IAuthRepository authRepository,
        ICryptographyService cryptographyService)
    {
        _logger = logger;
        _authTokenService = authTokenService;
        _authRepository = authRepository;
        _cryptographyService = cryptographyService;
    }

    /// <inheritdoc />
    public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request)
    {
        // Проверяем, не существует ли пользователь с таким email
        var existingUser = await _authRepository.GetUserByEmail(request.Email);
        if (existingUser != null)
        {
            return new CreateUserErrorResponse
            {
                Message = "Пользователь с таким email уже существует.",
                Code = ErrorCodes.UserDoesNotExist.ToString("D")
            };
        }

        var salt = _cryptographyService.GenerateSalt();
        var now = DateTime.UtcNow;

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Password = _cryptographyService.HashPassword(request.Password, salt),
            Salt = salt,
            Name = request.Name,
            LastName = request.LastName,
            Claims = ToClaims(request.Claims),
            CreateAt = now,
            UpdateAt = now
        };

        await _authRepository.CreateUser(user);

        _logger.LogInformation("Пользователь {Email} успешно создан", user.Email);

        return new CreateUserSuccessResponse
        {
            UserId = user.Id
        };
    }

    /// <summary>
    /// Преобразует список claim из запроса в доменные объекты.
    /// </summary>
    private static IList<Domain.User.Claim> ToClaims(IList<Request.Claim>? requestClaims)
    {
        if (requestClaims == null || requestClaims.Count == 0)
            return new List<Domain.User.Claim>();

        return requestClaims
            .Select(c => new Domain.User.Claim
            {
                Type = c.Type,
                Value = c.Value
            })
            .ToList();
    }
}