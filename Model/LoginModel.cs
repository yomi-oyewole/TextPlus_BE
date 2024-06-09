using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TextPlus_BE.Model
{
    public class LoginModel
    {

        [BsonElement("id")]
        public ObjectId Id { get; set; }

        [BsonElement("userId")]
        public ObjectId UserId { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonIgnore]
        public string? Password { get; set; }

        [BsonElement("passwordHash")]
        public byte[]? PasswordHash { get; set; }

        [BsonElement("passwordSalt")]
        public byte[]? PasswordSalt { get; set; }
    }
}
