using MongoDB.Bson;

namespace TextPlus_BE.Model
{
    public class MessageModel
    {
        public ObjectId Id { get; set; }
        public long CreatedDate { get; set; }
        public string? Message { get; set; }
        public string? Direction { get; set; }
        public string? Status { get; set; }
        public string? UserId { get; set; }
        public string? ConversationId { get; set; }

    }
}
