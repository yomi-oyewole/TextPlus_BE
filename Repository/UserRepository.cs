using TextPlus_BE.Dto;
using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;
using MongoDB.Driver;
using TextPlus_BE.Utilities;

namespace TextPlus_BE.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(IDbSettings dbSettings) : base(dbSettings, "User")
        {
        }

        public async Task<UserModel> RegisterAsync(RegisterModel model)
        {
            var a = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var date = DateUtils.ConvertToUnixTimestamp(DateTime.Now);
            Console.WriteLine(date);
            Console.WriteLine(a);
            var user = new UserModel
            {
                Email = model.Email!.ToLower(),
                Number = model.Number,
                CreatedAt = date
            };
            await _collection.InsertOneAsync(user);
            return user;
        }

        // Get User from db
        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            var context = await _collection.FindAsync(d => d.Email!.Equals(email, StringComparison.OrdinalIgnoreCase));
            var userContext = await context.ToListAsync();
            var user = userContext.SingleOrDefault();
            return user;
        }
    }

}
