using AutoMapper;
using MediatR;
using Udemy.Application.IRepositories;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQueryRequest, Result<IReadOnlyList<GetActivitiesQueryResponse>>>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetActivitiesQueryHandler(IActivityReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetActivitiesQueryResponse>>> Handle(GetActivitiesQueryRequest request, CancellationToken cancellationToken)
     {
          // istenen etkinlikleri getir
          var activities = await _readRepository.GetAllActivitiesForIndex();
          //var activities = await _readRepository.GetAllAsync();

          // maple
          //var activitiesToReturn = _mapper.Map<IReadOnlyList<GetActivitiesQueryResponse>>(activities);

          // gönder
          return Result<IReadOnlyList<GetActivitiesQueryResponse>>.Success(activities);
     }
}
