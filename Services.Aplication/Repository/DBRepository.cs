using Services.Aplication.Models;
using Services.Aplication.Enums;

namespace Services.Aplication.Repository;
public class DBRepository
{
    public List<TaskModel> Tasks { get; set; } = new List<TaskModel>{
      new TaskModel{
        Id = Guid.NewGuid(),
        Name = "Finaliza formação de C#",
        Description = "Finalizar o projeto completo de C#",
        DueDate = DateTime.Now,
        Priority = PriorityEnum.High,
        Status = StatusEnum.pending
      }
    };
}