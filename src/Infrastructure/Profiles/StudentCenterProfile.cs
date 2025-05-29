using AutoMapper;
using StudentCenterApi.src.Application.DTOs.RequestType;
using StudentCenterApi.src.Application.DTOs.Solicitation;
using StudentCenterApi.src.Application.DTOs.Status;
using StudentCenterApi.src.Application.DTOs.StudentCenter;
using StudentCenterApi.src.Application.DTOs.TimeLine;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Infrastructure.Profiles;

public class StudentCenterProfile : Profile
{
    public StudentCenterProfile()
    {
        CreateMap<TimeLine, TimeLineDto>().ReverseMap();       

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
        CreateMap<Solicitation, SolicitationUpdateStatusDto>().ReverseMap();
        CreateMap<Solicitation, SolicitationDto>()
            .ForMember(x => x.DescriptionStatus, x => x.MapFrom(x => x.Status.Description))
            .ForMember(x => x.DescriptionRequestType, x => x.MapFrom(x => x.RequestType.Description))
            .ReverseMap();
    }
}
