namespace Venhancer.Crowd.Identity.Shared.Configuration
{
    public class APIOptions
    {
        public string? CrowAPIBaseUrl { get; set; }
        public string? CrowAPICreateTokenUrl { get; set; }
        public string? CrowAPISingInUrl { get; set; }
        public string? CrowAPIGetUserDataUrl { get; set; }
        public string? CrowAPIGetAllUserDataUrl { get; set; }
        public string? CrowAPICreateUserUrl { get; set; }
        public string? CrowAPIRemoveUserUrl { get; set; }
    }
}
