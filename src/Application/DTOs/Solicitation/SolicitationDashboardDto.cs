namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public record SolicitationDashboardDto(string studentId,
                                       int statusId, 
                                       int count);

