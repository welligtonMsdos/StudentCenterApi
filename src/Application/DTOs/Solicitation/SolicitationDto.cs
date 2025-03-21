namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public record SolicitationDto(int Id, 
                              int StudentId, 
                              string Description, 
                              string DescriptionStatus, 
                              string DescriptionRequestType){}
