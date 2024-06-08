using MongoDB.Bson;

namespace TextPlus_BE.Model
{
    public class ConversationModel
    {
        public ObjectId Id { get; set; }
        public string? ExternalNumber { get; set; }
        public ObjectId UserId { get; set; }
        public string? ConversationId { get; set; }
        public long CreatedDate { get; set; }
        public long UpdatedDate { get; set; }

    }
}
