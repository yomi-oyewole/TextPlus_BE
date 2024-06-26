﻿using TextPlus_BE.Model;

namespace TextPlus_BE.Interfaces
{
    public interface IConversationRepository
    {
        Task<ConversationModel> CreateConversationAsync(ConversationModel model);

        Task<ConversationModel?> GetConversationByIdAsync(string conversationId);

        Task UpdateConversationAsync(string conversationId, long updatedDate);

        Task CreateManyConversationsAsync(List<ConversationModel> models);

        Task<List<ConversationModel>> GetConversationsByUserIdAsync(string userId);
    }
}
