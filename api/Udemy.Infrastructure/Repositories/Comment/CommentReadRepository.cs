using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Features.CommentOperations;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class CommentReadRepository : ReadRepository<Comment>, ICommentReadRepository
{
     private readonly ApplicationContext _context;
     private readonly IMapper _mapper;
     public CommentReadRepository(ApplicationContext context, IMapper mapper) : base(context)
     {
          _context = context;
          _mapper = mapper;
     }

     public async Task<IReadOnlyList<GetCommentsQueryResponse>> GetAllCommentsForActivity(Guid id)
     {
          var comments = await _context.Comments
               .Where(x => x.Activity.Id == id)
               .OrderByDescending(x => x.CreatedDate)
               .ProjectTo<GetCommentsQueryResponse>(_mapper.ConfigurationProvider)
               .ToListAsync();

          return comments;
     }
}
