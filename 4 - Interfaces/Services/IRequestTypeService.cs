using StudentCenterApi._1___Model;
using StudentCenterApi._5___Dtos.RequestType;

namespace StudentCenterApi._4___Interfaces.Services;

public interface IRequestTypeService
{
    Task<ICollection<RequestTypeDto>> GetAll();
    Task<RequestTypeDto> GetById(int id);
    Task<bool> Delete(RequestTypeDto requestTypeDto);
    Task<RequestType> Post(RequestTypeCreateDto requestTypeCreateDto);
    Task<RequestType> Put(RequestTypeUpdateDto requestTypeUpdateDto);
}
