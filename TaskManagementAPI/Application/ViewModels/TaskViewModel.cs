namespace Application.ViewModels;

public class TaskViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }

    public int ProjectId { get; set; }
    public ProjectViewModel? Project { get; set; }
}
