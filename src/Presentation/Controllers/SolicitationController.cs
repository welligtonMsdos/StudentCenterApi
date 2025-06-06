﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCenterApi.src.Application.DTOs.Solicitation;
using StudentCenterApi.src.Application.Interfaces;

namespace StudentCenterApi.src.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SolicitationController : BaseController
{
    private readonly ISolicitationService _service;    

    public SolicitationController(ISolicitationService service)
    {
        _service = service;        
    }

    [Authorize]
    [HttpGet("[Action]")]
    public async Task<IActionResult> GetByStatusId(int statusId, string studentId)
    {
        try
        {
            var solicitation = await _service.GetByStatusId(statusId, studentId);

            if (solicitation == null) return NotFound();

            return Ok(solicitation);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpGet("[Action]")]
    public async Task<IActionResult> GetByStudentId(string studentId)
    {
        try
        {
            var solicitation = await _service.GetByStudentId(studentId);

            if (solicitation == null) return NotFound();

            return Ok(solicitation);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpGet("[Action]")]
    public async Task<IActionResult> GetAllPendingStatuses()
    {
        try
        {
            var solicitation = await _service.GetAllPendingStatuses();

            if (solicitation == null) return NotFound();

            return Ok(solicitation);
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
            var solicitation = await _service.GetById(id);

            if (solicitation == null) return NotFound();

            return Ok(solicitation);
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

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<SolicitationDto>> Post([FromBody] SolicitationCreateDto dto)
    {      
        try
        {
            var result = await _service.Post(dto);

            var created = CreatedAtAction(nameof(Post), nameof(SolicitationController), new { id = result.Id }, result);
           
            return Sucess(created);
          
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult<SolicitationDto>> Put([FromBody] SolicitationUpdateDto dto)
    {
        try
        {
            if (dto.Id == 0) return Error("ID cannot be zero");

            var result = await _service.Put(dto);

            var update = CreatedAtAction(nameof(Put), nameof(SolicitationController), new { id = result.Id }, result);

            return Sucess(update, true);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [Authorize]
    [HttpPatch]
    public async Task<ActionResult<SolicitationDto>> UpdateStatus([FromBody] SolicitationUpdateStatusDto dto)
    {
        try
        {
            var update = await _service.UpdateStatus(dto);

            return Sucess(update, true);
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
