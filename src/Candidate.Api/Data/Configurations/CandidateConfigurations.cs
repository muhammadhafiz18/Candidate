using Candidate.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Candidate.Api.Data.Configurations;

public class CandidateConfigurations : IEntityTypeConfiguration<Models.Candidate>
{
    public void Configure(EntityTypeBuilder<Models.Candidate> builder)
    {
        builder.ToTable("Candidates");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(50);

        builder.Property(x => x.PreferredCallTime)
            .HasMaxLength(100);

        builder.Property(x => x.LinkedInUrl)
            .HasMaxLength(500);

        builder.Property(x => x.GitHubUrl)
            .HasMaxLength(500);

        builder.Property(x => x.Comment)
            .HasMaxLength(1000)
            .IsRequired();
    }
} 