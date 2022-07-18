using AutoMapper;
using MediatR;
using Udemy.Application.IRepositories;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivityDetailQueryHandler : IRequestHandler<GetActivityDetailQueryRequest, Result<GetActivityDetailQueryResponse>>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetActivityDetailQueryHandler(IActivityReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<Result<GetActivityDetailQueryResponse>> Handle(GetActivityDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // istenen etkinliği getir
          var activity = await _readRepository.GetActivityDetails(request.Id);

          // maple
          //var mappedActivity = _mapper.Map<GetActivityDetailQueryResponse>(activity);

          // gönder
          return Result<GetActivityDetailQueryResponse>.Success(activity);
     }
}
