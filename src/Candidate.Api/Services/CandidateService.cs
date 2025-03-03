using Candidate.Api.Repositories;

namespace Candidate.Api.Services;

public class CandidateService(ICandidateRepository repository) : ICandidateService
{
    public async Task UpsertCandidateAsync(Models.Candidate candidate, CancellationToken cancellationToken)
    {
        await repository.UpsertCandidateAsync(candidate, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
