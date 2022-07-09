using AutoMapper;
using MediatR;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivityDetailQueryHandler : IRequestHandler<GetActivityDetailQueryRequest, GetActivityDetailQueryResponse>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetActivityDetailQueryHandler(IActivityReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<GetActivityDetailQueryResponse> Handle(GetActivityDetailQueryRequest request, CancellationToken cancellationToken)
     {
          var activities = await _readRepository.GetByIdAsync(request.Id);
          return _mapper.Map<GetActivityDetailQueryResponse>(activities);
     }
}
