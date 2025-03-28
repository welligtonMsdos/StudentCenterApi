using StudentCenterApi.src.Application.DTOs.Solicitation;

namespace StudentCenterApi.src.Application.Interfaces;

public interface ISolicitationService
{
    Task<ICollection<SolicitationDto>> GetByStudentId(int studentId);
    Task<ICollection<SolicitationDto>> GetByStatusId(int statusId, int studentId);
    Task<ICollection<SolicitationDto>> GetAllPendingStatuses();
    Task<SolicitationDto> GetById(int id);
    Task<bool> Delete(SolicitationDto solicitationDto);
    Task<SolicitationDto> Post(SolicitationCreateDto solicitationCreateDto);
    Task<SolicitationDto> Put(SolicitationUpdateDto solicitationUpdateDto);
    Task<SolicitationDto> UpdateStatus(SolicitationUpdateStatusDto solicitationUpdateStatusDto);
}
