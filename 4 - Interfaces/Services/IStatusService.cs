using StudentCenterApi._5___Dtos.Status;

namespace StudentCenterApi._4___Interfaces.Services;

public interface IStatusService
{
    Task<ICollection<StatusDto>> GetAll();
    Task<StatusDto> GetById(int id);
}
