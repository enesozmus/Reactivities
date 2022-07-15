using MediatR;
using Udemy.Application.IRepositories;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class RemoveActivityCommandHandler : IRequestHandler<RemoveActivityCommandRequest, Result<Unit>>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IActivityWriteRepository _writeRepository;

     public RemoveActivityCommandHandler(IActivityWriteRepository writerepository, IActivityReadRepository readRepository)
     {
          _writeRepository = writerepository;
          _readRepository = readRepository;
     }

     public async Task<Result<Unit>> Handle(RemoveActivityCommandRequest request, CancellationToken cancellationToken)
     {
          // silinecek etkinliği getir
          var activity = await _readRepository.GetByIdAsync(request.Id);
          //if (activity == null) return null;

          // sil
          await _writeRepository.RemoveAsync(activity);

          // kaydet
          await _writeRepository.SaveAsync();

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
