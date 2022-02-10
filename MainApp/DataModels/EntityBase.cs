using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.DataModels;

public abstract class EntityBase
{
    public Guid Id { get; set; }

    [NotMapped]
    public bool IsNew { get; set; }
}