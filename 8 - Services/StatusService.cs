using AutoMapper;
using StudentCenterApi._4___Interfaces.Repository;
using StudentCenterApi._4___Interfaces.Services;
using StudentCenterApi._5___Dtos.Status;

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

    public async Task<ICollection<StatusDto>> GetAll()
    {
        return _mapper.Map<ICollection<StatusDto>>(await _repository.GetAll());
    }

    public async Task<StatusDto> GetById(int id)
    {
        return _mapper.Map<StatusDto>(await _repository.GetById(id));
    }
}
