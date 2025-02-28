using StudentCenterApi._5___Dtos.StudentCenter;

namespace StudentCenterApi._4___Interfaces.Services;

public interface IStudentCenterBaseService
{
    Task<ICollection<StudentCenterBaseDto>> GetAll();
    Task<StudentCenterBaseDto> GetById(int id);
    Task<bool> Delete(StudentCenterBaseDto studentCenterBase);
}
