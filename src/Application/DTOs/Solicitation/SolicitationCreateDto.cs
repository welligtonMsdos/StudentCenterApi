namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public record SolicitationCreateDto(int StudentId, 
                                    string Description, 
                                    int StatusId, 
                                    int RequestTypeId) {}

