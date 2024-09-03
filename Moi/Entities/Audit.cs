using System.ComponentModel.DataAnnotations;

namespace GaragesStructure.Entities;

public class Audit<TId>
{
    [Key]
    public Guid Id { get; set; }
    public string? TableName { get; set; }
    public TId? EntityId { get; set; }
    public string? Action { get; set; } // e.g., "INSERT", "UPDATE", "DELETE"
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? ChangedBy { get; set; }
    public DateTime ChangedAt { get; set; }
}