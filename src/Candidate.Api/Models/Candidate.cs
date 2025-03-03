namespace Candidate.Api.Models;

public class Candidate
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName  { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber  { get; set; }
    public string? PreferredCallTime { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public required string Comment { get; set; }
}