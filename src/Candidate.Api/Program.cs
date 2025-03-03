using Candidate.Api.Data;
using Candidate.Api.Repositories;
using Candidate.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CandidateDbContext>(options =>  
    options.UseNpgsql(builder.Configuration.GetConnectionString("Candidates"))); 

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

var app = builder.Build();

app.Run();