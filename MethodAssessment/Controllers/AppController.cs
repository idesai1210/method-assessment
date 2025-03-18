using MethodAssessment.Dto;
using MethodAssessment.Services;
using Microsoft.AspNetCore.Mvc;

namespace MethodAssessment.Controllers;

[Route("api/app")]
[ApiController]
public class AppController : Controller
{
    private readonly AppService _appService = new();

    [HttpGet]
    public async Task<ActionResult<AppDto>> GetStrings()
    {
        try
        {
            var data = await _appService.GenerateUniqueStrings();
            var dto = new AppDto
            {
                data = data
            };
            return Ok(dto);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while generating strings.");
        }
    }

    [HttpGet("dynamic")]
    public async Task<ActionResult<AppDto>> GetStrings(int size)
    {
        try
        {
            if (size <= 0 || size > 1000)
                return BadRequest("Page size must be between 1 and 1000.");
            var data = await _appService.GenerateUniqueStrings(size);
            var dto = new AppDto
            {
                data = data
            };
            return Ok(dto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpGet("page")]
    public async Task<ActionResult<PaginatedAppDto>> GetStrings(int size, int page)
    {
        try
        {
            var data = await _appService.GenerateUniqueStrings(size, page);
            var dto = new PaginatedAppDto()
            {
                data = data,
                pageInfo = new PageDto()
                {
                    page = page,
                    size = size
                }
            };
            return Ok(dto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}