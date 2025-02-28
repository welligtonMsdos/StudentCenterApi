using AutoMapper;
using FluentValidation.Results;
using StudentCenterApi._1___Model;
using StudentCenterApi._4___Interfaces.Repository;
using StudentCenterApi._4___Interfaces.Services;
using StudentCenterApi._5___Dtos.Status;
using StudentCenterApi.A___Validation;

namespace StudentCenterApi._8___Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _repository;
    private readonly IMapper _mapper;

    public StatusService(IStatusRepository repository,
                         IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Delete(StatusDto statusDto)
    {
        return await _repository.Delete(_mapper.Map<Status>(statusDto));
    }

    public async Task<ICollection<StatusDto>> GetAll()
    {
        return _mapper.Map<ICollection<StatusDto>>(await _repository.GetAll());
    }

    public async Task<StatusDto> GetById(int id)
    {
        return _mapper.Map<StatusDto>(await _repository.GetById(id));
    }

    public async Task<Status> Post(StatusCreateDto statusCreateDto)
    {
        var status = _mapper.Map<Status>(statusCreateDto);

        ValidationResult valid = new StatusValidation().Validate(status);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return await _repository.Post(status);
    }

    public async Task<Status> Put(StatusUpdateDto statusUpdateDto)
    {
        var status = _mapper.Map<Status>(statusUpdateDto);

        ValidationResult valid = new StatusValidation().Validate(status);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return await _repository.Put(status);
    }   
}
