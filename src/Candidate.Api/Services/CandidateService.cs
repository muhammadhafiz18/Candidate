using Candidate.Api.Repositories;

namespace Candidate.Api.Services;

public class CandidateService(ICandidateRepository repository) : ICandidateService
{
    public async Task<bool> UpsertCandidateAsync(Models.Candidate candidate, CancellationToken cancellationToken)
    {
        var isNew = await repository.UpsertCandidateAsync(candidate, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return isNew;
    }
}
