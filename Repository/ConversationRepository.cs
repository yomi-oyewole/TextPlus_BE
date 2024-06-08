using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;

namespace TextPlus_BE.Repository
{
    public class ConversationRepository : Repository<ConversationModel>, IConversationRepository
    {
        public ConversationRepository(IDbSettings dbSettings) : base(dbSettings, "Conversation")
        {
        }
    }
}
