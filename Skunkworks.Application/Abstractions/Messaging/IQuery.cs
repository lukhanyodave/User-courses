using MediatR;
using Skunkworks.Shared;

namespace Skunkworks.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
