using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Venhancer.Crowd.Resume.Service.API.Models
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdateDate { get; set; }
    }
}
