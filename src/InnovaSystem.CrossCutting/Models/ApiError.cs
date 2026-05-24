namespace InnovaSystem.CrossCutting.Models
{
    public class ApiError
    {
        public string? ErrorCode { get; set; }
        public string? ErrorTitle { get; set; }
        public string? FriendlyErrorDescription { get; set; }
        public string? TechnicalErrorDescription { get; set; }
    }
}
