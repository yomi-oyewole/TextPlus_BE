using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Utilities;

namespace TextPlus_BE.Repository.RepoService
{

    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMessageRepository _messageRepository;

        public ConversationService(IServiceProvider serviceProvider)
        {
            _conversationRepository = serviceProvider.GetRequiredService<IConversationRepository>();
            _messageRepository = serviceProvider.GetRequiredService<IMessageRepository>();
        }

        public async Task<ConversationModel> CreateConversationAsync(ConversationModel model)
        {
            // create if conversation does not exist, else only update the updated time
            var conversation = await _conversationRepository.GetConversationByIdAsync(model.ConversationId!);
            if (conversation == null)
            {
                conversation = await _conversationRepository.CreateConversationAsync(model);
            }
            else
            {
                conversation.UpdatedDate = DateUtils.ConvertToUnixTimestamp(DateTime.Now);
                await _conversationRepository.UpdateConversationAsync(conversation.ConversationId!, conversation.UpdatedDate);
            }
            return conversation;
        }

        // public async Task<ConversationModel?> GetConversationByIdAsync(string id)
        // {
        //     var conversation = await _conversationRepository.GetConversationByIdAsync(id);
        //     return conversation;
        // }

        public async Task UpdateConversationAsync(string conversationId, long updatedDate)
        {
            await _conversationRepository.UpdateConversationAsync(conversationId, updatedDate);
        }

        public async Task<MessageModel?> CreateMessageAsync(MessageModel model)
        {
            // throw error if conversation does not exist
            var conversation = await _conversationRepository.GetConversationByIdAsync(model.ConversationId!);
            if (conversation == null)
            {
                return null;
            }
            var message = await _messageRepository.CreateMessageAsync(model);
            return message;
        }

        public async Task<List<MessageModel>> GetMessagesByConversationIdAsync(string conversationId)
        {
            var messages = await _messageRepository.GetMessagesByConversationIdAsync(conversationId);
            return messages;
        }

        // create many conversations
        public async Task CreateManyConversationsAsync(List<ConversationModel> models)
        {
            await _conversationRepository.CreateManyConversationsAsync(models);
        }

        // create many messages
        public async Task CreateManyMessagesAsync(List<MessageModel> models)
        {
            await _messageRepository.CreateManyMessagesAsync(models);
        }

        // Get conversation by user id
        public async Task<List<ConversationModel>> GetConversationsByUserIdAsync(string userId)
        {
            var conversations = await _conversationRepository.GetConversationsByUserIdAsync(userId);
            return conversations;
        }

    }

}
