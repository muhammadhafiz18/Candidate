using Candidate.Api.Data;
using Candidate.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CandidateDbContext>(options =>  
    options.UseNpgsql(builder.Configuration.GetConnectionString("Candidates"))); 

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

var app = builder.Build();

app.Run();