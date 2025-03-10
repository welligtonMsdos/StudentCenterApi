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

    public async Task<ICollection<SolicitationDto>> GetAll()
    {
        return _mapper.Map<ICollection<SolicitationDto>>(await _repository.GetAll());
    }

    public async Task<SolicitationDto> GetById(int id)
    {
        return _mapper.Map<SolicitationDto>(await _repository.GetById(id));
    }

    public async Task<Solicitation> Post(SolicitationCreateDto solicitationCreateDto)
    {
        var solicitation = _mapper.Map<Solicitation>(solicitationCreateDto);

        ValidationResult valid = new SolicitationValidation().Validate(solicitation);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return await _repository.Post(solicitation);
    }

    public async Task<Solicitation> Put(SolicitationUpdateDto solicitationUpdateDto)
    {
        var solicitation = _mapper.Map<Solicitation>(solicitationUpdateDto);

        ValidationResult valid = new SolicitationValidation().Validate(solicitation);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return await _repository.Put(solicitation);
    }
}
