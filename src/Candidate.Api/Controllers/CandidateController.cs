using Candidate.Api.Dtos;
using Candidate.Api.Services;
using Candidate.Api.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Api.Controllers;

[ApiController, Route("api/[controller]")]
public class CandidateController(
    ILogger<CandidateController> logger,
    ICandidateService candidateService,
    IValidator<CandidateUpsertRequest> validator) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> UpsertAsync(
        [FromBody] CandidateUpsertRequest candidateUpsertRequest,
        CancellationToken abortionToken = default)
    {
        var validationResult = await validator.ValidateAsync(candidateUpsertRequest, abortionToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        logger.LogInformation(
            "Candidate received: {firstName}, {lastName}, {email}",
            candidateUpsertRequest.FirstName,
            candidateUpsertRequest.LastName,
            candidateUpsertRequest.Email);

        try
        {
            var candidate = new Models.Candidate
            {
                FirstName = candidateUpsertRequest.FirstName!,
                LastName = candidateUpsertRequest.LastName!,
                Email = candidateUpsertRequest.Email!,
                PhoneNumber = candidateUpsertRequest.PhoneNumber,
                PreferredCallTime = candidateUpsertRequest.PreferredCallTime,
                LinkedInUrl = candidateUpsertRequest.LinkedInUrl,
                GitHubUrl = candidateUpsertRequest.GitHubUrl,
                Comment = candidateUpsertRequest.Comment!
            };
            
            var isNew = await candidateService.UpsertCandidateAsync(candidate, abortionToken);
            if (isNew)
            {
                return Created(uri: $"api/candidates/{candidate.Id}", value: candidate);
            }
            return NoContent();
        }
        catch (NotSupportedException ex)
        {
            logger.LogError(ex, "Error while creating a candidate.");
            return new StatusCodeResult(500);
        }
    }
}