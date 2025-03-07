namespace Candidate.Api.Repositories;

public interface ICandidateRepository
{
    Task<Models.Candidate?> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> UpsertCandidateAsync(Models.Candidate candidate, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}