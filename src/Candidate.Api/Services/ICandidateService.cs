namespace Candidate.Api.Services;

public interface ICandidateService
{
    Task<bool> UpsertCandidateAsync(Models.Candidate candidate, CancellationToken cancellationToken);
}