using MongoDB.Bson;

namespace TextPlus_BE.Model
{
    public class LoginModel
    {

        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
