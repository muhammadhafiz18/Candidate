using Candidate.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Api.Repositories;

public class CandidateRepository(CandidateDbContext context) : ICandidateRepository
{
    public async Task<Models.Candidate?> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken)
        => await context.Candidates.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);

    public async Task<bool> UpsertCandidateAsync(Models.Candidate candidate, CancellationToken cancellationToken)
    {
        var existingCandidate = await GetCandidateByEmailAsync(candidate.Email, cancellationToken);

        if (existingCandidate is null)
        {
            await context.Candidates.AddAsync(candidate, cancellationToken);
            return true;
        }
        
        existingCandidate.FirstName = candidate.FirstName;
        existingCandidate.LastName = candidate.LastName;
        existingCandidate.Email = candidate.Email;
        existingCandidate.PhoneNumber = candidate.PhoneNumber;
        existingCandidate.PreferredCallTime = candidate.PreferredCallTime;
        existingCandidate.LinkedInUrl = candidate.LinkedInUrl;
        existingCandidate.GitHubUrl = candidate.GitHubUrl;
        existingCandidate.Comment = candidate.Comment;
        return false;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await context.SaveChangesAsync(cancellationToken);
}