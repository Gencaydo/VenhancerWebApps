namespace Venhancer.Crowd.Identity.Core.Dtos
{
    public class BaseDto
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int QueryId { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
