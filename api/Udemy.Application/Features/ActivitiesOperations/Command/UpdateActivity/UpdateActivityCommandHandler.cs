using AutoMapper;
using MediatR;
using Udemy.Application.IRepositories;

namespace Udemy.Application.Features.ActivitiesOperations;

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommandRequest>
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

     public async Task<Unit> Handle(UpdateActivityCommandRequest request, CancellationToken cancellationToken)
     {
          var updated = await _readRepository.GetByIdAsync(request.Activity.Id);

          _mapper.Map(request.Activity, updated);

          //updated.Title = request.Activity.Title ?? updated.Title;

          await _writeRepository.SaveAsync();
          return Unit.Value;
     }
}
