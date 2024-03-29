namespace Com.MSAT.Infrastructure.Models;

public abstract class Entity
{
    public virtual long Id { get; protected set; }
    public required string CreatedBy { get; set; } // Added audit field
    public DateTime CreatedAt { get; set; } // Added audit field
    public required string UpdatedBy { get; set; } // Added audit field
    public DateTime UpdatedAt { get; set; } // Added audit field
}