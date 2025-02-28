﻿using Microsoft.AspNetCore.Mvc;
using StudentCenterApi._4___Interfaces.Services;

namespace StudentCenterApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StatusController : BaseController
{
    private readonly IStatusService _service;
    public StatusController(IStatusService service)
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
            var status = await _service.GetById(id);

            if(status == null) return NotFound();

            return Ok(status);
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
            if(id == 0) return NotFound();

            var status = await _service.GetById(id);

            var result = await _service.Delete(status);

            if (!result) return Error("Error when deleting record");

            return Sucess("successfully deleted");
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
