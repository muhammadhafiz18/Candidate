using Candidate.Api.Data;
using Candidate.Api.Dtos;
using Candidate.Api.Repositories;
using Candidate.Api.Services;
using Candidate.Api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CandidateDbContext>(options =>  
    options.UseNpgsql(builder.Configuration.GetConnectionString("Candidates")));
     
builder.Services.AddControllers();

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IValidator<CandidateUpsertRequest>, CandidateUpsertRequestValidator>();

var app = builder.Build();

app.UseRouting();
app.MapControllers(); 

app.Run();