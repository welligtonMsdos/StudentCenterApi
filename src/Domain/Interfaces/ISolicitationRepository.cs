using StudentCenterApi.src.Application.DTOs.Solicitation;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Interfaces;

public interface ISolicitationRepository
{
    Task<ICollection<Solicitation>> GetByStudentId(string studentId);
    Task<ICollection<Solicitation>> GetByStatusId(int statusId, string studentId);
    Task<ICollection<Solicitation>> GetAllPendingStatuses();
    Task<Solicitation> GetById(int id);
    Task<ICollection<SolicitationDashboardDto>> GetDashboardByStudentId(string studentId);
    Task<Solicitation> Post(Solicitation entity);
    Task<Solicitation> Put(Solicitation entity);
    Task<bool> Delete(Solicitation entity);
    Task<Solicitation> UpdateStatus(Solicitation entity);
}
