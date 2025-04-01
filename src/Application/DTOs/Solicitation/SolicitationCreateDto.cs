namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public record SolicitationCreateDto(int StudentId, 
                                    string Description,                                    
                                    int RequestTypeId) {}


