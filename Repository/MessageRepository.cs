using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;

namespace TextPlus_BE.Repository
{
    public class MessageRepository : Repository<MessageModel>, IMessageRepository
    {
        public MessageRepository(IDbSettings dbSettings) : base(dbSettings, "Message")
        {
        }
    }
}
