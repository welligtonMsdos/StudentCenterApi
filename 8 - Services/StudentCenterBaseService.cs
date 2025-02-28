using AutoMapper;
using FluentValidation.Results;
using StudentCenterApi._1___Model;
using StudentCenterApi._4___Interfaces.Repository;
using StudentCenterApi._4___Interfaces.Services;
using StudentCenterApi._5___Dtos.StudentCenter;
using StudentCenterApi.A___Validation;

namespace StudentCenterApi._8___Services;

public class StudentCenterBaseService : IStudentCenterBaseService
{
    private readonly IStudentCenterBaseRepository _repository;
    private readonly IMapper _mapper;

    public StudentCenterBaseService(IStudentCenterBaseRepository repository,
                                    IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Delete(StudentCenterBaseDto studentCenterBaseDto)
    {
        return await _repository.Delete(_mapper.Map<StudentCenterBase>(studentCenterBaseDto));
    }

    public async Task<ICollection<StudentCenterBaseDto>> GetAll()
    {
        return _mapper.Map<ICollection<StudentCenterBaseDto>>(await _repository.GetAll());
    }

    public async Task<StudentCenterBaseDto> GetById(int id)
    {
        return _mapper.Map<StudentCenterBaseDto>(await _repository.GetById(id));
    }

    public async Task<StudentCenterBase> Post(StudentCenterBaseCreateDto studentCenterBaseCreateDto)
    {
        var studentCenterBase = _mapper.Map<StudentCenterBase>(studentCenterBaseCreateDto);

        ValidationResult valid = new StudentCenterBaseValidation().Validate(studentCenterBase);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return await _repository.Post(studentCenterBase);
    }

    public async Task<StudentCenterBase> Put(StudentCenterBaseUpdateDto studentCenterBaseUpdateDto)
    {
        var studentCenterBase = _mapper.Map<StudentCenterBase>(studentCenterBaseUpdateDto);

        ValidationResult valid = new StudentCenterBaseValidation().Validate(studentCenterBase);

        string[] erros = valid.ToString("~").Split('~');

        if (!valid.IsValid) throw new Exception(erros[0]);

        return await _repository.Put(studentCenterBase);
    }
}
