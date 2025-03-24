using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Interfaces;

public interface ISolicitationRepository
{
    Task<ICollection<Solicitation>> GetByStudentId(int studentId);
    Task<ICollection<Solicitation>> GetByStatusId(int statusId, int studentId);
    Task<ICollection<Solicitation>> GetAllPendingStatuses();
    Task<Solicitation> GetById(int id);
    Task<Solicitation> Post(Solicitation entity);
    Task<Solicitation> Put(Solicitation entity);
    Task<bool> Delete(Solicitation entity);
}
