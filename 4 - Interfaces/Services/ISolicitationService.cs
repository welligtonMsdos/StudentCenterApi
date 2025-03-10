using StudentCenterApi._1___Model;
using StudentCenterApi._5___Dtos.Solicitation;

namespace StudentCenterApi._4___Interfaces.Services;

public interface ISolicitationService
{
    Task<ICollection<SolicitationDto>> GetAll();
    Task<SolicitationDto> GetById(int id);
    Task<bool> Delete(SolicitationDto solicitationDto);
    Task<Solicitation> Post(SolicitationCreateDto solicitationCreateDto);
    Task<Solicitation> Put(SolicitationUpdateDto solicitationUpdateDto);
}
