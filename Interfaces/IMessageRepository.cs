using TextPlus_BE.Model;

namespace TextPlus_BE.Interfaces
{
    public interface IMessageRepository
    {
        Task<MessageModel> CreateMessageAsync(MessageModel model);
        Task<List<MessageModel>> GetMessagesByConversationIdAsync(string conversationId);
        Task CreateManyMessagesAsync(List<MessageModel> models);
    }
}
