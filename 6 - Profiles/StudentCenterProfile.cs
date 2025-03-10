using AutoMapper;
using StudentCenterApi._1___Model;
using StudentCenterApi._5___Dtos.RequestType;
using StudentCenterApi._5___Dtos.Solicitation;
using StudentCenterApi._5___Dtos.Status;
using StudentCenterApi._5___Dtos.StudentCenter;

namespace StudentCenterApi._6___Profiles;

public class StudentCenterProfile : Profile
{
    public StudentCenterProfile()
    {
        CreateMap<Status, StatusDto>().ReverseMap();
        CreateMap<Status, StatusCreateDto>().ReverseMap();
        CreateMap<Status, StatusUpdateDto>().ReverseMap();

        CreateMap<StudentCenterBase, StudentCenterBaseDto>().ReverseMap();
        CreateMap<StudentCenterBase, StudentCenterBaseCreateDto>().ReverseMap();
        CreateMap<StudentCenterBase, StudentCenterBaseUpdateDto>().ReverseMap();

        CreateMap<RequestType, RequestTypeDto>().ReverseMap();
        CreateMap<RequestType, RequestTypeCreateDto>().ReverseMap();
        CreateMap<RequestType, RequestTypeUpdateDto>().ReverseMap();

        CreateMap<Solicitation, SolicitationCreateDto>().ReverseMap();
        CreateMap<Solicitation, SolicitationUpdateDto>().ReverseMap();
        CreateMap<Solicitation, SolicitationDto>()
            .ForMember(x => x.DescriptionStatus, x => x.MapFrom(x => x.Status.Description))
            .ForMember(x => x.DescriptionRequestType, x => x.MapFrom(x => x.RequestType.Description))
            .ReverseMap();
    }
}
