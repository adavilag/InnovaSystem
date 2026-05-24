using InnovaSystem.Core.Application.Common.Interfaces.CQRS;
using InnovaSystem.Core.Application.Common.Models;

namespace InnovaSystem.WebApi.Services
{
    public sealed class RequestContextAccessor : IRequestContextAccessor
    {
        public RequestContext? Context { get; set; } = new();
    }
}
