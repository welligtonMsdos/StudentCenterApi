using AutoMapper;
using StudentCenterApi._1___Model;
using StudentCenterApi._5___Dtos.Status;
using StudentCenterApi._5___Dtos.StudentCenter;

namespace StudentCenterApi._6___Profiles;

public class StudentCenterProfile : Profile
{
    public StudentCenterProfile()
    {
        CreateMap<Status, StatusDto>().ReverseMap();
        CreateMap<StudentCenterBase, StudentCenterBaseDto>().ReverseMap();
    }
}
