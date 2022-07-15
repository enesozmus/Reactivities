using MediatR;

namespace Udemy.Application.Features.AuthenticationOperations;

public class GetCurrentUserQueryRequest : IRequest<GetCurrentUserQueryResponse> { }
