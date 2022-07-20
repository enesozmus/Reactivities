using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class PhotoReadRepository : ReadRepository<Photo>, IPhotoReadRepository
{
     public PhotoReadRepository(ApplicationContext context) : base(context) { }
}
