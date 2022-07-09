using Udemy.Domain.Entities;

namespace Udemy.Application.IRepositories;

public interface IRepository<T> where T : BaseEntity
{
     IQueryable<T> Table { get; }
     IQueryable<T> TableNoTracking { get; }
}
