using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.SignalR;
using StudentCenterApi.src.Application.DTOs.Solicitation;
using StudentCenterApi.src.Application.Interfaces;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Domain.Model;
using StudentCenterApi.src.Domain.Validation;
using StudentCenterApi.src.Infrastructure.Util;

namespace StudentCenterApi.src.Application.Services;

public class SolicitationService : ISolicitationService
{
    private readonly ISolicitationRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHubContext<StatusHub> _hubContext;

    public SolicitationService(ISolicitationRepository repository,
                               IMapper mapper,
                               IHubContext<StatusHub> hubContext)
    {
        _repository = repository;
        _mapper = mapper;
        _hubContext = hubContext;
    }

    public async Task<bool> Delete(SolicitationDto solicitationDto)
    {
        return await _repository.Delete(_mapper.Map<Solicitation>(solicitationDto));
    }

    public async Task<ICollection<SolicitationDto>> GetAllPendingStatuses()
    {
        return _mapper.Map<ICollection<SolicitationDto>>(await _repository.GetAllPendingStatuses());
    }

    public async Task<SolicitationDto> GetById(int id)
    {
        return _mapper.Map<SolicitationDto>(await _repository.GetById(id));
    }

    public async Task<ICollection<SolicitationDto>> GetByStatusId(int statusId, string studentId)
    {
        return _mapper.Map<ICollection<SolicitationDto>>(await _repository.GetByStatusId(statusId, studentId));
    }

    public async Task<ICollection<SolicitationDto>> GetByStudentId(string studentId)
    {
        return _mapper.Map<ICollection<SolicitationDto>>(await _repository.GetByStudentId(studentId));
    }

    public async Task<SolicitationDto> Post(SolicitationCreateDto solicitationCreateDto)
    {
        var solicitation = _mapper.Map<Solicitation>(solicitationCreateDto);

        ValidationResult valid = new SolicitationValidation().Validate(solicitation);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return _mapper.Map<SolicitationDto>(await _repository.Post(solicitation));
    }

    public async Task<SolicitationDto> Put(SolicitationUpdateDto solicitationUpdateDto)
    {
        var solicitation = _mapper.Map<Solicitation>(solicitationUpdateDto);

        ValidationResult valid = new SolicitationValidation().Validate(solicitation);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return _mapper.Map<SolicitationDto>(await _repository.Put(solicitation));
    }

    public async Task<SolicitationDto> UpdateStatus(SolicitationUpdateStatusDto solicitationUpdateStatusDto)
    {
        var solicitation = _mapper.Map<Solicitation>(solicitationUpdateStatusDto);

        var update = await _repository.UpdateStatus(solicitation);

        await _hubContext.Clients.All.SendAsync("ReceiveIdAndDescription", update.Id, update.Status.Description.ToLower());

        return _mapper.Map<SolicitationDto>(update);
    }
}
