using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TextPlus_BE.Model
{
    public class MessageModel
    {
        [BsonElement("id")]
        public ObjectId Id { get; set; }

        [BsonElement("createdDate")]
        public long CreatedDate { get; set; }

        [BsonElement("body")]
        public string? Body { get; set; }

        [BsonElement("direction")]
        public string? Direction { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("userId")]
        public ObjectId UserId { get; set; }

        [BsonElement("conversationId")]
        public string? ConversationId { get; set; }

    }
}
