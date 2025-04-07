using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCenterApi.src.Application.DTOs.RequestType;
using StudentCenterApi.src.Application.Interfaces;

namespace StudentCenterApi.src.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RequestTypeController : BaseController
{
    private readonly IRequestTypeService _service;
    public RequestTypeController(IRequestTypeService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("[Action]")]
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
            var requestType = await _service.GetById(id);

            if (requestType == null) return NotFound();

            return Ok(requestType);
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

            var requestType = await _service.GetById(id);

            var result = await _service.Delete(requestType);

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
    public async Task<ActionResult<RequestTypeDto>> Post([FromBody] RequestTypeCreateDto dto)
    {
        try
        {
            var result = await _service.Post(dto);            

            var created = CreatedAtAction(nameof(Post), nameof(RequestTypeController), new { id = result.Id }, result);

            return Sucess(created);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult<RequestTypeDto>> Put([FromBody] RequestTypeUpdateDto dto)
    {
        try
        {
            if (dto.Id == 0) return Error("ID cannot be zero");

            var result = await _service.Put(dto);

            var update = CreatedAtAction(nameof(Put), nameof(RequestTypeController), new { id = result.Id }, result);

            return Sucess(update, true);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
