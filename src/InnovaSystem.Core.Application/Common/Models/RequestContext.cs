namespace InnovaSystem.Core.Application.Common.Models
{
    public sealed class RequestContext
    {
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? IpAddress { get; set; }

        public string? Device { get; set; }

        public string? Location { get; set; }

        public string? CorrelationId { get; set; }

        public bool IsAuthenticated { get; set; }

        public DateTime RequestTime { get; set; }
    }
}
