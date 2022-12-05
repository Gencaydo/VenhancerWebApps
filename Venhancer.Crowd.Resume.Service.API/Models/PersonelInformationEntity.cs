using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Venhancer.Crowd.Resume.Service.API.Models
{
    public class PersonelInformationEntity : BaseEntity
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        public string? HomeAddress { get; set; }
    }
}
