using AutoMapper;
using StudentCenterApi.src.Application.DTOs.TimeLine;
using StudentCenterApi.src.Application.Interfaces;
using StudentCenterApi.src.Domain.Interfaces;

namespace StudentCenterApi.src.Application.Services;

public class TimeLineService : ITimeLineService
{
    private readonly ITimeLineRepository _repository;
    private readonly IMapper _mapper;

    public TimeLineService(ITimeLineRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<TimeLineDto>> GetByStudentId(string studentId)
    {
        return _mapper.Map<ICollection<TimeLineDto>>(await _repository.GetByStudentId(studentId));
    }   
}
