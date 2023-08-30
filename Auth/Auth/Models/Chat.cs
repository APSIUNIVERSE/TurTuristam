namespace Auth.Models;

public class Chat
{
    public int Id { get; set; }
    public string? TuristId { get; set; }
    
    public string? AgentId { get; set; }
    public DateTime? DateTime { get; set; }
    public string? TuristName { get; set; }
}