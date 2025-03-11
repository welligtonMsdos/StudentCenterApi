using StudentCenterApi._1___Model;

namespace StudentCenterApi._4___Interfaces.Repository;

public interface ISolicitationRepository
{
    Task<ICollection<Solicitation>> GetByStudentId(int studentId);
    Task<ICollection<Solicitation>> GetByStatusId(int statusId);
    Task<Solicitation> GetById(int id);
    Task<Solicitation> Post(Solicitation entity);
    Task<Solicitation> Put(Solicitation entity);
    Task<bool> Delete(Solicitation entity);
}
