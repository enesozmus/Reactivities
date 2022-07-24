using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ProfilesOperations;

public class GetUserActivitiesQueryHandler : IRequestHandler<GetUserActivitiesQueryRequest, Result<List<GetUserActivitiesQueryResponse>>>
{
     private readonly IActivityAttendeeReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetUserActivitiesQueryHandler(IActivityAttendeeReadRepository readRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<List<GetUserActivitiesQueryResponse>>> Handle(GetUserActivitiesQueryRequest request, CancellationToken cancellationToken)
     {
          var query = await _readRepository.GetUserActivities(u => u.AppUser.UserName == request.Username);

          query = request.Predicate switch
          {
               "past" => query.Where(a => a.Date <= DateTime.Now),
               "hosting" => query.Where(a => a.HostUsername == request.Username),
               _ => query.Where(a => a.Date >= DateTime.Now)
          };

          var activities = await query.ToListAsync();

          return Result<List<GetUserActivitiesQueryResponse>>.Success(activities);

     }
}
