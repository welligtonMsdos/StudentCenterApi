using StudentCenterApi.src.Application.DTOs.Status;

namespace StudentCenterApi.src.Application.Interfaces;

public interface IStatusService
{
    Task<ICollection<StatusDto>> GetAll();
    Task<StatusDto> GetById(int id);
    Task<bool> Delete(StatusDto statusDto);
    Task<StatusDto> Post(StatusCreateDto statusCreateDto);
    Task<StatusDto> Put(StatusUpdateDto statusUpdateDto);
}
