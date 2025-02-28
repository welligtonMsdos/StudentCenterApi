using AutoMapper;
using StudentCenterApi._1___Model;
using StudentCenterApi._4___Interfaces.Repository;
using StudentCenterApi._4___Interfaces.Services;
using StudentCenterApi._5___Dtos.StudentCenter;

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

    public async Task<bool> Delete(StudentCenterBaseDto studentCenterBase)
    {
        return await _repository.Delete(_mapper.Map<StudentCenterBase>(studentCenterBase));
    }

    public async Task<ICollection<StudentCenterBaseDto>> GetAll()
    {
        return _mapper.Map<ICollection<StudentCenterBaseDto>>(await _repository.GetAll());
    }

    public async Task<StudentCenterBaseDto> GetById(int id)
    {
        return _mapper.Map<StudentCenterBaseDto>(await _repository.GetById(id));
    }
}
