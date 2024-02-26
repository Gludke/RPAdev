using System.ComponentModel.DataAnnotations;

namespace RPAdev.Domain.Models;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }
}