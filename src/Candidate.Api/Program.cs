using Candidate.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CandidateDbContext>(options =>  
    options.UseNpgsql(builder.Configuration.GetConnectionString("Candidates")));  

var app = builder.Build();

app.Run();
