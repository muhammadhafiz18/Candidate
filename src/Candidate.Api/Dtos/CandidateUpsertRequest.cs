using System.ComponentModel.DataAnnotations;

namespace Candidate.Api.Dtos;

public class CandidateUpsertRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; }
    public string? PreferredCallTime { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public string? Comment { get; set; }
}