using StudentCenterApi.src.Application.DTOs.RequestType;

namespace StudentCenterApi.src.Application.Interfaces;

public interface IRequestTypeService
{
    Task<ICollection<RequestTypeDto>> GetAll();
    Task<RequestTypeDto> GetById(int id);
    Task<bool> Delete(RequestTypeDto requestTypeDto);
    Task<RequestTypeDto> Post(RequestTypeCreateDto requestTypeCreateDto);
    Task<RequestTypeDto> Put(RequestTypeUpdateDto requestTypeUpdateDto);
}
