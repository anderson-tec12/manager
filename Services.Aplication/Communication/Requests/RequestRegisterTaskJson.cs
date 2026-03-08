namespace Services.Aplication.Communication.Requests;
using Services.Aplication.Enums;
public class RequestRegisterTaskJson
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public PriorityEnum Priority { get; set; }
    public StatusEnum Status { get; set; }
}