using AutoMapper;
using MediatR;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQueryRequest, Result<PagedList<GetActivitiesQueryResponse>>>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IUserAccessor _userAccessor;
     private readonly IMapper _mapper;

     public GetActivitiesQueryHandler(IActivityReadRepository readRepository, IUserAccessor userAccessor, IMapper mapper)
     {
          _readRepository = readRepository;
          _userAccessor = userAccessor;
          _mapper = mapper;
     }

     public async Task<Result<PagedList<GetActivitiesQueryResponse>>> Handle(GetActivitiesQueryRequest request, CancellationToken cancellationToken)
     {
          // istenen etkinlikleri getir
          var query = await _readRepository.GetAllActivitiesForIndex();

          var username = _userAccessor.GetUsername();

          if (request.Params.IsGoing && !request.Params.IsHost)
          {
               query = query.Where(x => x.Attendees.Any(a => a.UserName == _userAccessor.GetUsername()));
          }

          if (request.Params.IsHost && !request.Params.IsGoing)
          {
               query = query.Where(x => x.HostUsername == _userAccessor.GetUsername());
          }

          // maple
          //var activitiesToReturn = _mapper.Map<IReadOnlyList<GetActivitiesQueryResponse>>(activities);

          // gönder
          return Result<PagedList<GetActivitiesQueryResponse>>.Success(
               await PagedList<GetActivitiesQueryResponse>
               .CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
     }
}
