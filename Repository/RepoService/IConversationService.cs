using TextPlus_BE.Model;

namespace TextPlus_BE.Repository.RepoService
{
    public interface IConversationService
    {
        Task<ConversationModel> CreateConversationAsync(ConversationModel model);
        Task UpdateConversationAsync(string conversationId, long updatedDate);
        Task<MessageModel?> CreateMessageAsync(MessageModel model);
        Task<List<MessageModel>> GetMessagesByConversationIdAsync(string conversationId);
        Task CreateManyConversationsAsync(List<ConversationModel> models);
        Task CreateManyMessagesAsync(List<MessageModel> models);
        Task<List<ConversationModel>> GetConversationsByUserIdAsync(string userId);

    }

}

