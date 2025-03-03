using Microsoft.EntityFrameworkCore;

namespace Candidate.Api.Data;

public interface ICandidateDbContext
{
    DbSet<Models.Candidate> Candidates { get; set; }
}