using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Interfaces;

public interface ITimeLineRepository
{
    Task<ICollection<TimeLine>> GetByStudentId(string studentId);   
}
