using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCenterApi.src.Application.Interfaces;

namespace StudentCenterApi.src.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TimeLineController : BaseController
{
    private readonly ITimeLineService _timeLineService;

    public TimeLineController(ITimeLineService timeLineService)
    {
        _timeLineService = timeLineService;
    }

    [Authorize]
    [HttpGet("[Action]")]
    public async Task<IActionResult> GetByStudentId(string studentId)
    {
        try
        {
            var timeLine = await _timeLineService.GetByStudentId(studentId);

            if (timeLine == null) return NotFound();

            return Ok(timeLine);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
