using StudentCenterApi.src.Application.DTOs.TimeLine;

namespace StudentCenterApi.src.Application.Interfaces;

public interface ITimeLineService
{
    Task<ICollection<TimeLineDto>> GetByStudentId(string studentId);   
}
