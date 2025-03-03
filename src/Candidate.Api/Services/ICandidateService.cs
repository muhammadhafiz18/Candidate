namespace Candidate.Api.Services;

public interface ICandidateService
{
    Task UpsertCandidateAsync(Models.Candidate candidate, CancellationToken cancellationToken);
}