namespace Progredi.DataAccess.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BackgroundColorHex { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public List<TaskItem> TaskItems { get; set; } = [];
}