using Services.Aplication.Enums;

namespace Services.Aplication.Models;


public class TaskModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityEnum Priority { get; set; } 
    public DateTime DueDate { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.pending;
}