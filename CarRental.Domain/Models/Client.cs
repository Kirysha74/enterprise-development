namespace CarRental.Domain.Models;

/// <summary>
/// Car rental service client
/// </summary>
public class Client
{
    /// <summary>
    /// Unique client identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Driver's license number
    /// </summary>
    public required string LicenseNumber { get; set; }

    /// <summary>
    /// Client's full name
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Client's date of birth
    /// </summary>
    public required DateOnly BirthDate { get; set; }
}