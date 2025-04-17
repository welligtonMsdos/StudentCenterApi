﻿namespace StudentCenterApi.src.Domain.Model;

public class Status
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public ICollection<Solicitation> Solicitation { get; set; }
}
