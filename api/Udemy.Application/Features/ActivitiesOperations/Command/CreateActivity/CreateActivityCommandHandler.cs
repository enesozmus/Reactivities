using AutoMapper;
using MediatR;
using Udemy.Application.IRepositories;
using Udemy.Application.Result;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommandRequest, Result<Unit>>
{
     private readonly IActivityWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public CreateActivityCommandHandler(IActivityWriteRepository writerepository, IMapper mapper)
     {
          _writeRepository = writerepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(CreateActivityCommandRequest request, CancellationToken cancellationToken)
     {
          // maple
          var activity = _mapper.Map<Activity>(request);

          // ekle
          await _writeRepository.AddAsync(activity);
          if (activity == null) return Result<Unit>.Failure("Yeni etkinlik eklenirken bir hata oluştu!");
          
          // kaydet
          await _writeRepository.SaveAsync();

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
