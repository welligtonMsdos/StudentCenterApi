using StudentCenterApi._1___Model;
using StudentCenterApi._5___Dtos.Status;

namespace StudentCenterApi._4___Interfaces.Services;

public interface IStatusService
{
    Task<ICollection<StatusDto>> GetAll();
    Task<StatusDto> GetById(int id);
    Task<bool> Delete(StatusDto statusDto);
    Task<Status> Post(StatusCreateDto statusCreateDto);
    Task<Status> Put(StatusUpdateDto statusUpdateDto);
}
