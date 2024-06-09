namespace TextPlus_BE.Utilities
{
    public static class ConversationUtils
    {
        // Concatenate userId with number divded by a stroke
        public static string GenerateConversationId(string userId, string externalNumber)
        {
            externalNumber = externalNumber.Replace("+", "");
            return $"{userId}|{externalNumber}";
        }

        // Split the conversationId by the stroke
        public static (string userId, string externalNumber) SplitConversationId(string conversationId)
        {
            var parts = conversationId.Split('|');
            return (parts[0], parts[1]);
        }
    }
}


