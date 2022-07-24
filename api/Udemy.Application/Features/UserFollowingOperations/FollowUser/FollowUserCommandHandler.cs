using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.UserFollowingOperations;

public class FollowUserCommandHandler : IRequestHandler<FollowUserCommandRequest, Result<Unit>>
{
     private readonly IUserFollowingWriteRepository _writeRepository;
     private readonly IUserFollowingReadRepository _readRepository;
     private readonly IUserAccessor _userAccessor;
     private readonly UserManager<AppUser> _userManager;

     public FollowUserCommandHandler(IUserFollowingWriteRepository writeRepository, IUserAccessor userAccessor, UserManager<AppUser> userManager, IUserFollowingReadRepository readRepository)
     {
          _writeRepository = writeRepository;
          _userAccessor = userAccessor;
          _userManager = userManager;
          _readRepository = readRepository;
     }

     public async Task<Result<Unit>> Handle(FollowUserCommandRequest request, CancellationToken cancellationToken)
     {
          // takip edecek kişi
          var observer = await _userManager
               .Users
               .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

          // takip edilen kişi
          var target = await _userManager
               .Users
               .FirstOrDefaultAsync(x => x.UserName == request.TargetUsername);

          if (target == null) return null;


          //var following = await _readRepository.GetByIdAsync(observer.Id);
          var following = await _readRepository.GetForMultipleKeys(observer.Id, target.Id);
          //var following = await _context.UserFollowings.FindAsync(observer.Id, target.Id);

          if (following == null)
          {
               following = new UserFollowing
               {
                    Observer = observer,
                    Target = target
               };
               await _writeRepository.AddAsync(following);
          }
          else
          {
               await _writeRepository.RemoveAsync(following);
          }

          await _writeRepository.SaveAsync();
          return Result<Unit>.Success(Unit.Value);
     }
}
