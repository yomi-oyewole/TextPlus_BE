using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TextPlus_BE.Model
{
    public class ConversationModel
    {
        public ConversationModel()
        {
            Id = ObjectId.GenerateNewId();
        }

        [BsonElement("id")]
        public ObjectId Id { get; private set; }

        [BsonElement("externalNumber")]
        public string? ExternalNumber { get; set; }

        [BsonElement("userId")]
        public ObjectId UserId { get; set; }

        [BsonElement("conversationId")]
        public string? ConversationId { get; set; }

        [BsonElement("createdDate")]
        public long CreatedDate { get; set; }

        [BsonElement("updatedDate")]
        public long UpdatedDate { get; set; }

    }
}
