using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;

namespace TextPlus_BE.Repository
{
    public class UserRepository : Repository<MessageModel>, IUserRepository
    {
        public UserRepository(IDbSettings dbSettings) : base(dbSettings, "User")
        {
        }
    }
}
