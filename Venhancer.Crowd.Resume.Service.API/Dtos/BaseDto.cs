namespace Venhancer.Crowd.Resume.Service.API.Dtos
{
    public class BaseDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
