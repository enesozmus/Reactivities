using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.CommentOperations;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQueryRequest, Result<IReadOnlyList<GetCommentsQueryResponse>>>
{
     private readonly ICommentReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetCommentsQueryHandler(ICommentReadRepository readRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetCommentsQueryResponse>>> Handle(GetCommentsQueryRequest request, CancellationToken cancellationToken)
     {
          var comments = await _readRepository.GetAllCommentsForActivity(request.ActivityId);

          return Result<IReadOnlyList<GetCommentsQueryResponse>>.Success(comments);
     }
}
