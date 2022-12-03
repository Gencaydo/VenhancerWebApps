using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Venhancer.Crowd.Resume.Service.API.Models
{
    public class ResumeEntity : BaseEntity
    {
        public List<CVTypeEntity>? CVTypes { get; set; }
        public List<PersonelInformationEntity>? PersonelInformations { get; set; }
    }
}
