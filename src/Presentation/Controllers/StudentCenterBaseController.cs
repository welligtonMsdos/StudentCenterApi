using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCenterApi.src.Application.DTOs.StudentCenter;
using StudentCenterApi.src.Application.Interfaces;

namespace StudentCenterApi.src.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentCenterBaseController : BaseController
{
    private readonly IStudentCenterBaseService _service;
    public StudentCenterBaseController(IStudentCenterBaseService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _service.GetAll());
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var status = await _service.GetById(id);

            if (status == null) return NotFound();

            return Ok(status);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            if (id == 0) return NotFound();

            var studentCenterBase = await _service.GetById(id);

            var result = await _service.Delete(studentCenterBase);

            if (!result) return Error("Error when deleting record");

            return Sucess("successfully deleted");
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<StudentCenterBaseDto>> Post([FromBody] StudentCenterBaseCreateDto dto)
    {
        try
        {
            var result = await _service.Post(dto);

            var created = CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

            return Sucess(created);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult<StudentCenterBaseDto>> Put([FromBody] StudentCenterBaseUpdateDto dto)
    {
        try
        {
            if (dto.Id == 0) return Error("ID cannot be zero");

            var result = await _service.Put(dto);

            var update = CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

            return Sucess(update, true);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
