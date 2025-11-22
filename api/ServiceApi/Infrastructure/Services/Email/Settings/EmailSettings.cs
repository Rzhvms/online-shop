namespace Infrastructure.Services.Email.Settings;

public class EmailSettings
{
    /// <summary>
    /// TODO
    /// </summary>
    public string Host { get; set; } = default!;

    /// <summary>
    /// TODO
    /// </summary>
    public int Port { get; set; } = 465;

    /// <summary>
    /// TODO
    /// </summary>
    public bool UseSsl { get; set; } = true;

    /// <summary>
    /// TODO
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// TODO
    /// </summary>
    public string Password { get; set; } = default!;

    /// <summary>
    /// TODO
    /// </summary>
    public string FromAddress { get; set; } = default!;

    /// <summary>
    /// TODO
    /// </summary>
    public string FromName { get; set; } = "Server";

    /// <summary>
    /// TODO
    /// </summary>
    public string RecipientName { get; set; } = "client";
}