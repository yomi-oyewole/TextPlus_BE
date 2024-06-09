using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using TextPlus_BE.Dto;
using TextPlus_BE.Model;
using TextPlus_BE.Repository.RepoService;
using TextPlus_BE.Utilities;

namespace TextPlus_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversationController : BaseController
    {

        private readonly IConversationService conversationService;
        public ConversationController(IServiceProvider serviceProvider)
        {
            conversationService = serviceProvider.GetRequiredService<IConversationService>();
        }

        // [HttpPost("createConversation")]
        // public async Task<IActionResult> CreateConversation([FromBody] ConversationModel model)
        // {
        //     var conversation = await conversationService.CreateConversationAsync(model);
        //     return Ok(conversation);
        // }

        // [HttpGet("getConversationById")]
        // public async Task<IActionResult> GetConversationById(string id)
        // {
        //     var conversation = await conversationService.GetConversationByIdAsync(id);
        //     return Ok(conversation);
        // }

        // [HttpPost("updateConversation")]
        // public async Task<IActionResult> UpdateConversation([FromBody] ConversationModel model)
        // {
        //     await conversationService.UpdateConversationAsync(model);
        //     return Ok();
        // }

        [HttpPost("createMessage")]
        public async Task<IActionResult> CreateMessage([FromBody] MessageModelDto model)
        {
            // Todo: extract conversationId from model and check if conversation exists
            // Make request via third party service to send message

            var message = await conversationService.CreateMessageAsync(new MessageModel
            {
                ConversationId = model.ConversationId,
                UserId = new ObjectId(model.UserId),
                Body = model.Body,
                Direction = model.Direction,
                Status = model.Status,
                CreatedDate = DateUtils.ConvertToUnixTimestamp(DateTime.Now)
            });

            if (message == null)
            {
                return BadRequest("Conversation does not exist");
            }
            // Update conversation updated time
            var updatedDate = DateUtils.ConvertToUnixTimestamp(DateTime.Now);
            await conversationService.UpdateConversationAsync(model.ConversationId!, updatedDate);

            return Ok(message);
        }

        [HttpGet("getMessagesByConversationId")]
        public async Task<IActionResult> GetMessagesByConversationId([FromQuery] string conversationId)
        {
            var messages = await conversationService.GetMessagesByConversationIdAsync(conversationId);
            return Ok(messages);
        }


        [HttpPost("compose")]
        public async Task<IActionResult> ComponseConversations([FromBody] ComposeDto models)
        {
            // Todo: Send message to third party service

            List<ConversationModel> conversations = new List<ConversationModel>();
            List<MessageModel> messages = new List<MessageModel>();
            var UserId = new ObjectId(models.UserId);
            var date = DateUtils.ConvertToUnixTimestamp(DateTime.Now);

            // Create an object of conversation model for eact To in composeDto
            foreach (var to in models.To)
            {
                var conversation = new ConversationModel
                {
                    UserId = UserId,
                    CreatedDate = date,
                    UpdatedDate = date,
                    ExternalNumber = to
                };

                conversation.ConversationId = ConversationUtils.GenerateConversationId(conversation.UserId.ToString(), to);
                conversations.Add(conversation);
                var message = new MessageModel
                {
                    ConversationId = conversation.ConversationId,
                    CreatedDate = date,
                    Direction = "outbound",
                    Status = "sent",
                    UserId = UserId,
                    Body = models.Body
                };
                messages.Add(message);
            }

            var conversationTask = conversationService.CreateManyConversationsAsync(conversations);
            var messageTask = conversationService.CreateManyMessagesAsync(messages);
            List<Task> tasks = new List<Task> { conversationTask, messageTask };
            await Task.WhenAll(tasks);
            return Ok();
        }

        [HttpGet("getConversationsByUserId")]
        public async Task<IActionResult> GetConversationsByUserId([FromQuery] string userId)
        {
            var conversations = await conversationService.GetConversationsByUserIdAsync(userId);
            return Ok(conversations);
        }


        // [HttpPost("createManyConversations")]
        // public async Task<IActionResult> CreateManyConversations([FromBody] List<ConversationModel> models)
        // {
        //     await conversationService.CreateManyConversationsAsync(models);
        //     return Ok();
        // }

        // [HttpPost("createManyMessages")]
        // public async Task<IActionResult> CreateManyMessages([FromBody] List<MessageModel> models)
        // {
        //     await conversationService.CreateManyMessagesAsync(models);
        //     return Ok();
        // }

    }
}

