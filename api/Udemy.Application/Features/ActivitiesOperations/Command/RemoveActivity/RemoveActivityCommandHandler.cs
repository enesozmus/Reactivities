using MediatR;
using Udemy.Application.IRepositories;

namespace Udemy.Application.Features.ActivitiesOperations;

public class RemoveActivityCommandHandler : IRequestHandler<RemoveActivityCommandRequest>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IActivityWriteRepository _writeRepository;

     public RemoveActivityCommandHandler(IActivityWriteRepository writerepository, IActivityReadRepository readRepository)
     {
          _writeRepository = writerepository;
          _readRepository = readRepository;
     }

     public async Task<Unit> Handle(RemoveActivityCommandRequest request, CancellationToken cancellationToken)
     {
          var deleted = await _readRepository.GetByIdAsync(request.Id);
          await _writeRepository.RemoveAsync(deleted);
          await _writeRepository.SaveAsync();
          return Unit.Value;
     }
}
