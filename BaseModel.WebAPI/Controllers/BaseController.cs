using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

public abstract class BaseController : ControllerBase
{
    protected IActionResult CustomResponse(ValidationResult validationResult)
    {
        if (validationResult.IsValid)
            return Ok();

        return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
    }
}