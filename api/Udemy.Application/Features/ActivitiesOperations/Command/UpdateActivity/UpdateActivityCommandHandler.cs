using AutoMapper;
using MediatR;
using Udemy.Application.IRepositories;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommandRequest, Result<Unit>>
{
     private readonly IActivityWriteRepository _writeRepository;
     private readonly IActivityReadRepository _readRepository;
     private readonly IMapper _mapper;

     public UpdateActivityCommandHandler(IActivityWriteRepository writeRepository, IActivityReadRepository readRepository, IMapper mapper)
     {
          _writeRepository = writeRepository;
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(UpdateActivityCommandRequest request, CancellationToken cancellationToken)
     {
          // güncellenek etkinliği getir
          var activity = await _readRepository.GetByIdAsync(request.Id);
          if (activity == null) return null;

          // maple
          _mapper.Map(request, activity);
          //updated.Title = request.Activity.Title ?? updated.Title;

          // kaydet
          await _writeRepository.SaveAsync();

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
