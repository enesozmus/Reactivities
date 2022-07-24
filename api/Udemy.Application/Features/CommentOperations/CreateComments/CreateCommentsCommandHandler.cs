using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.CommentOperations;

public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommandRequest, Result<CreateCommentsCommandResponse>>
{
     
     private readonly IActivityReadRepository _activityReadRepository;
     private readonly ICommentWriteRepository _commentWriteRepository;
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly UserManager<AppUser> _userManager;
     private readonly IUserAccessor _userAccessor;
     private readonly IMapper _mapper;

     public CreateCommentsCommandHandler(IActivityReadRepository activityReadRepository, ICommentWriteRepository commentWriteRepository, UserManager<AppUser> userManager, IUserAccessor userAccessor, IMapper mapper, IHttpContextAccessor httpContextAccessor)
     {
          _activityReadRepository = activityReadRepository;
          _commentWriteRepository = commentWriteRepository;
          _userManager = userManager;
          _userAccessor = userAccessor;
          _mapper = mapper;
          _httpContextAccessor = httpContextAccessor;
     }

     public async Task<Result<CreateCommentsCommandResponse>> Handle(CreateCommentsCommandRequest request, CancellationToken cancellationToken)
     {
          var activity = await _activityReadRepository.GetByIdAsync(request.ActivityId);
          if (activity == null) return null;

          var userName = _userAccessor.GetUsername();
          
          var username = _httpContextAccessor.HttpContext.User.Identity?.Name;
          //var appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity?.Name);
          //string userName = appUser.UserName;

          var user = _userManager
               .Users
               .Include(x => x.Photos)
               .SingleOrDefault(x => x.UserName == username);

          var comment = new Comment
          {
               AppUser = user,
               Activity = activity,
               Body = request.Body
          };

          await _commentWriteRepository.AddAsync(comment);
          await _commentWriteRepository.SaveAsync();
          return Result<CreateCommentsCommandResponse>.Success(_mapper.Map<CreateCommentsCommandResponse>(comment));
     }
}
