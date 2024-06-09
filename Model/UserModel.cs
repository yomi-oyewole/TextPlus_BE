using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TextPlus_BE.Model
{
    public class UserModel
    {

        [BsonElement("id")]
        public ObjectId Id { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("number")]
        public string? Number { get; set; }

        [BsonElement("createdAt")]
        public long? CreatedAt { get; set; }
    }
}
