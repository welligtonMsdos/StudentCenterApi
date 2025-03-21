namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public record SolicitationUpdateDto(int Id, 
                                    int StudentId, 
                                    string Description, 
                                    int StatusId, 
                                    int RequestTypeId) {}
