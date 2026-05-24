using InnovaSystem.Core.Application.Common.Interfaces.CQRS;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.WebApi.Controllers.v1
{
    [ApiController]
    public abstract class ApiControllerBase(IRequestContextAccessor requestContextAccesor) : ControllerBase
    {
        protected readonly IRequestContextAccessor RequestContextAccesor = requestContextAccesor;
    }
}
