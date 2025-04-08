namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public record SolicitationUpdateDto(int Id, 
                                    string  StudentId,
                                    string Description,
                                    int StatusId,
                                    int RequestTypeId);