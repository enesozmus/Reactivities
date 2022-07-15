using MediatR;
using Udemy.Application.Result;
using Udemy.Application.Test;

namespace Udemy.Application.Features.AuthenticationOperations;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
     private readonly IAuthentication _authentication;

     public LoginCommandHandler(IAuthentication authentication) => _authentication = authentication;

     //private readonly UserManager<AppUser> _userManager;
     //private readonly SignInManager<AppUser> _signInManager;
     //private readonly IMapper _mapper;

     //public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
     //{
     //     _userManager = userManager;
     //     _signInManager = signInManager;
     //     _mapper = mapper;
     //}

     public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
     {
          return await _authentication.LoginAsync(request);
     }

     //public async Task<Result<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
     //{
     //     //return null
     //     //var neilCodes = await _userManager.FindByEmailAsync(request.Email);

     //     //It worked and returned a user
     //     var user = _userManager.Users.SingleOrDefault(x => x.Email == request.Email);

     //     if (user == null) return Result<LoginCommandResponse>.Failure("Email veya şifre hatalı!");

     //     var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

     //     var userModel = _mapper.Map<LoginCommandResponse>(user);

     //     if (result.Succeeded)
     //          return Result<LoginCommandResponse>.Success(userModel);
     //     else
     //          return Result<LoginCommandResponse>.Failure("Email veya şifre hatalı!");
     //}
}
