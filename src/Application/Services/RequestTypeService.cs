using AutoMapper;
using FluentValidation.Results;
using StudentCenterApi.src.Application.DTOs.RequestType;
using StudentCenterApi.src.Application.Interfaces;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Domain.Model;
using StudentCenterApi.src.Domain.Validation;

namespace StudentCenterApi.src.Application.Services;

public class RequestTypeService : IRequestTypeService
{
    private readonly IRequestTypeRepository _repository;
    private readonly IMapper _mapper;

    public RequestTypeService(IRequestTypeRepository repository,
                              IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Delete(RequestTypeDto requestTypeDto)
    {
        return await _repository.Delete(_mapper.Map<RequestType>(requestTypeDto));
    }

    public async Task<ICollection<RequestTypeDto>> GetAll()
    {
        return _mapper.Map<ICollection<RequestTypeDto>>(await _repository.GetAll());
    }

    public async Task<RequestTypeDto> GetById(int id)
    {
        return _mapper.Map<RequestTypeDto>(await _repository.GetById(id));
    }

    public async Task<RequestTypeDto> Post(RequestTypeCreateDto requestTypeCreateDto)
    {
        var requestType = _mapper.Map<RequestType>(requestTypeCreateDto);

        ValidationResult valid = new RequestTypeValidation().Validate(requestType);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return _mapper.Map<RequestTypeDto>(await _repository.Post(requestType));
    }

    public async Task<RequestTypeDto> Put(RequestTypeUpdateDto requestTypeUpdateDto)
    {
        var requestType = _mapper.Map<RequestType>(requestTypeUpdateDto);

        ValidationResult valid = new RequestTypeValidation().Validate(requestType);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return _mapper.Map<RequestTypeDto>(await _repository.Put(requestType));
    }
}
