using MongoDB.Bson;

namespace TextPlus_BE.Model
{
    public class UserModel
    {
        public ObjectId Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Number { get; set; }
    }
}
