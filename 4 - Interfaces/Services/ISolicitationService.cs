using StudentCenterApi._5___Dtos.Solicitation;

namespace StudentCenterApi._4___Interfaces.Services;

public interface ISolicitationService
{   
    Task<ICollection<SolicitationDto>> GetByStudentId(int studentId);
    Task<ICollection<SolicitationDto>> GetByStatusId(int statusId);
    Task<SolicitationDto> GetById(int id);
    Task<bool> Delete(SolicitationDto solicitationDto);
    Task<SolicitationDto> Post(SolicitationCreateDto solicitationCreateDto);
    Task<SolicitationDto> Put(SolicitationUpdateDto solicitationUpdateDto);
}
