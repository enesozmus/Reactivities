using AutoMapper;
using MediatR;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQueryRequest, IReadOnlyList<GetActivitiesQueryResponse>>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetActivitiesQueryHandler(IActivityReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<IReadOnlyList<GetActivitiesQueryResponse>> Handle(GetActivitiesQueryRequest request, CancellationToken cancellationToken)
     {
          var activities = await _readRepository.GetAllAsync();
          return _mapper.Map<IReadOnlyList<GetActivitiesQueryResponse>>(activities);
     }
}
