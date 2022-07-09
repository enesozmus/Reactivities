using MediatR;
using Udemy.Application.IRepositories;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommandRequest>
{
     private readonly IActivityWriteRepository _writeRepository;

     public CreateActivityCommandHandler(IActivityWriteRepository writerepository)
     {
          _writeRepository = writerepository;
     }

     public async Task<Unit> Handle(CreateActivityCommandRequest request, CancellationToken cancellationToken)
     {
          await _writeRepository.AddAsync(request.Activity);
          await _writeRepository.SaveAsync();
          return Unit.Value;
     }
}
