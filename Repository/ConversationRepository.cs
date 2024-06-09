using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TextPlus_BE.Repository
{
    public class ConversationRepository : Repository<ConversationModel>, IConversationRepository
    {
        public ConversationRepository(IDbSettings dbSettings) : base(dbSettings, "Conversation")
        {
        }

        public async Task<ConversationModel> CreateConversationAsync(ConversationModel model)
        {
            await _collection.InsertOneAsync(model);
            return model;
        }

        public async Task CreateManyConversationsAsync(List<ConversationModel> models)
        {
            await _collection.InsertManyAsync(models);
        }

        public async Task<ConversationModel?> GetConversationByIdAsync(string conversationId)
        {
            var context = await _collection.FindAsync(d => d.ConversationId!.Equals(conversationId));
            var conversationContext = await context.ToListAsync();
            var conversation = conversationContext.SingleOrDefault();
            return conversation;
        }

        // update conversation updated time
        public async Task UpdateConversationAsync(string conversationId, long updatedDate)
        {
            var filter = Builders<ConversationModel>.Filter.Eq(s => s.ConversationId, conversationId);
            var update = Builders<ConversationModel>.Update
                .Set(s => s.UpdatedDate, updatedDate);
            await _collection.UpdateOneAsync(filter, update);
        }

        // Get conversation by user id
        public async Task<List<ConversationModel>> GetConversationsByUserIdAsync(string userId)
        {
            var context = await _collection.FindAsync(d => d.UserId!.Equals(new ObjectId(userId)));
            var conversationContext = await context.ToListAsync();
            return conversationContext;
        }
    }
}
