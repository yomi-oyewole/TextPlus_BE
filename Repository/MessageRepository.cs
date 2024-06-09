using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;
using MongoDB.Driver;

namespace TextPlus_BE.Repository
{
    public class MessageRepository : Repository<MessageModel>, IMessageRepository
    {
        public MessageRepository(IDbSettings dbSettings) : base(dbSettings, "Message")
        {
        }


        public async Task<MessageModel> CreateMessageAsync(MessageModel model)
        {
            await _collection.InsertOneAsync(model);
            return model;
        }

        public async Task<List<MessageModel>> GetMessagesByConversationIdAsync(string conversationId)
        {
            var context = await _collection.FindAsync(d => d.ConversationId!.Equals(conversationId));
            var messageContext = await context.ToListAsync();
            return messageContext;
        }

        // Create many messages
        public async Task CreateManyMessagesAsync(List<MessageModel> models)
        {
            await _collection.InsertManyAsync(models);
        }
    }
}
