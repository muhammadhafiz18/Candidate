using Candidate.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Api.Repositories;

public class CandidateRepository(CandidateDbContext context) : ICandidateRepository
{
    public async Task<Models.Candidate?> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken)
        => await context.Candidates.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);

    public async Task UpsertCandidateAsync(Models.Candidate candidate, CancellationToken cancellationToken)
    {
        var existingCandidate = await GetCandidateByEmailAsync(candidate.Email, cancellationToken);

        if (existingCandidate is null)
            await context.Candidates.AddAsync(candidate, cancellationToken);
        else
            context.Entry(existingCandidate).CurrentValues.SetValues(candidate);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await context.SaveChangesAsync(cancellationToken);
}