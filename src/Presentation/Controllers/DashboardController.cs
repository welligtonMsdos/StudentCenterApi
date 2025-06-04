using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCenterApi.src.Application.Interfaces;

namespace StudentCenterApi.src.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DashboardController : BaseController
{
    private readonly IDashboardService _service;

    public DashboardController(IDashboardService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("[Action]")]
    public async Task<IActionResult> GetUsers(string studentId)
    {
        try
        {
            return Ok(await _service.GetDashboardByStudentId(studentId));
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
