using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;

namespace TextPlus_BE.Repository
{
    public class LoginRepository : Repository<LoginModel>, ILoginRepository
    {
        public LoginRepository(IDbSettings dbSettings) : base(dbSettings, "Login")
        {
        }
    }
}
