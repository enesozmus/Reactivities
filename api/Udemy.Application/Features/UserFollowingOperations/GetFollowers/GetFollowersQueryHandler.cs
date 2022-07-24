using AutoMapper;
using MediatR;
using Udemy.Application.Features.ProfilesOperations;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;

namespace Udemy.Application.Features.UserFollowingOperations;

public class GetFollowersQueryHandler : IRequestHandler<GetFollowersQueryRequest, Result<List<GetProfilesQueryResponse>>>
{
     private readonly IUserFollowingReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetFollowersQueryHandler(IUserFollowingReadRepository readRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<List<GetProfilesQueryResponse>>> Handle(GetFollowersQueryRequest request, CancellationToken cancellationToken)
     {
          List<GetProfilesQueryResponse> profiles = new();

          switch (request.Predicate)
          {
               case "followers":
                    profiles = await _readRepository
                         .GetTargetProfiles(x => x.Target.UserName == request.Username);
                    break;
               case "following":
                    profiles = await _readRepository
                         .GetObserverProfiles(x => x.Observer.UserName == request.Username);
                    break;
          }

          return Result<List<GetProfilesQueryResponse>>.Success(profiles);
     }
}
