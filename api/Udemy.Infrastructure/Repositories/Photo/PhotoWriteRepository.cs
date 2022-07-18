using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class PhotoWriteRepository : WriteRepository<Photo>, IPhotoWriteRepository
{
     public PhotoWriteRepository(ApplicationContext context) : base(context) { }
}
