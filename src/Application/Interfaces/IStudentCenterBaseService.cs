using StudentCenterApi.src.Application.DTOs.StudentCenter;

namespace StudentCenterApi.src.Application.Interfaces;

public interface IStudentCenterBaseService
{
    Task<ICollection<StudentCenterBaseDto>> GetAll();
    Task<StudentCenterBaseDto> GetById(int id);
    Task<bool> Delete(StudentCenterBaseDto studentCenterBaseDto);
    Task<StudentCenterBaseDto> Post(StudentCenterBaseCreateDto studentCenterBaseCreateDto);
    Task<StudentCenterBaseDto> Put(StudentCenterBaseUpdateDto studentCenterBaseUpdateDto);
}
