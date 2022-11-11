namespace Venhancer.Crowd.Identity.Core.Models
{
    public class Base
    {
        public string? id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
