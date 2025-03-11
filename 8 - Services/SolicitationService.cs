using AutoMapper;
using FluentValidation.Results;
using StudentCenterApi._1___Model;
using StudentCenterApi._4___Interfaces.Repository;
using StudentCenterApi._4___Interfaces.Services;
using StudentCenterApi._5___Dtos.Solicitation;
using StudentCenterApi.A___Validation;

namespace StudentCenterApi._8___Services;

public class SolicitationService : ISolicitationService
{
    private readonly ISolicitationRepository _repository;
    private readonly IMapper _mapper;

    public SolicitationService(ISolicitationRepository repository,
                               IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Delete(SolicitationDto solicitationDto)
    {
        return await _repository.Delete(_mapper.Map<Solicitation>(solicitationDto));
    }   

    public async Task<SolicitationDto> GetById(int id)
    {
        return _mapper.Map<SolicitationDto>(await _repository.GetById(id));
    }

    public async Task<ICollection<SolicitationDto>> GetByStatusId(int statusId)
    {
        return _mapper.Map<ICollection<SolicitationDto>>(await _repository.GetByStatusId(statusId));
    }

    public async Task<ICollection<SolicitationDto>> GetByStudentId(int studentId)
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
}
