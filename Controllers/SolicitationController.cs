using Microsoft.AspNetCore.Mvc;
using StudentCenterApi._1___Model;
using StudentCenterApi._4___Interfaces.Services;
using StudentCenterApi._5___Dtos.Solicitation;

namespace StudentCenterApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SolicitationController : BaseController
{
    private readonly ISolicitationService _service;
    public SolicitationController(ISolicitationService service)
    {
        _service = service;
    }

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var solicitation = await _service.GetById(id);

            if (solicitation == null) return NotFound();

            return Ok(solicitation);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            if (id == 0) return NotFound();

            var solicitation = await _service.GetById(id);

            var result = await _service.Delete(solicitation);

            if (!result) return Error("Error when deleting record");

            return Sucess("successfully deleted");
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Solicitation>> Post([FromBody] SolicitationCreateDto dto)
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

    [HttpPut]
    public async Task<ActionResult<Solicitation>> Put([FromBody] SolicitationUpdateDto dto)
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
