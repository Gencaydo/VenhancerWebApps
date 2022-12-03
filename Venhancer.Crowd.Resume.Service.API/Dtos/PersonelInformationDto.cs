namespace Venhancer.Crowd.Resume.Service.API.Dtos
{
    public class PersonelInformationDto : BaseDto
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? HomeAddress { get; set; }
        public string? NotificationType { get; set; }
    }
}
