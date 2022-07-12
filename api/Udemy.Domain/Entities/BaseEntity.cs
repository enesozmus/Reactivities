namespace Udemy.Domain.Entities;

public abstract class BaseEntity
{
     public Guid Id { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime? LastModifiedDate { get; set; }
}
