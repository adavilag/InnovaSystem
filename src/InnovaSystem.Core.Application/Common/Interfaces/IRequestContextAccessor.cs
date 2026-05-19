using InnovaSystem.Core.Application.Common.Models;

namespace InnovaSystem.Core.Application.Common.Interfaces
{
    public interface IRequestContextAccessor
    {
        RequestContext? Context { get; set; }
    }
}
