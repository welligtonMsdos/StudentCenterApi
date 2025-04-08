namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public record SolicitationCreateDto(string StudentId, 
                                    string Description, 
                                    int RequestTypeId);