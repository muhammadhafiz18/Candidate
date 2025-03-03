using Microsoft.EntityFrameworkCore;

namespace Candidate.Api.Data;

public class CandidateDbContext(DbContextOptions<CandidateDbContext> options)
    : DbContext(options), ICandidateDbContext
{
    public DbSet<Models.Candidate> Candidates { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.CandidateConfigurations());
    }
}