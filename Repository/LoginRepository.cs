using MongoDB.Bson;
using MongoDB.Driver;
using TextPlus_BE.Helper.Security;
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

        public async Task<bool> LoginAsync(LoginDto model)
        {

            var context = await _collection.FindAsync(d => d.Email!.Equals(model.Email, StringComparison.OrdinalIgnoreCase));
            var loginContext = await context.ToListAsync();
            var login = loginContext.SingleOrDefault();

            if (login == null)
                return false;

            if (!AuthProvider.VerifyPasswordHash(model.Password!, login.PasswordHash, login.PasswordSalt))
                return false;

            return true;
        }

        public async Task<LoginModel> AddLoginContextAsync(string password, string userId, string email)
        {

            AuthProvider.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var user = new LoginModel
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserId = new ObjectId(userId),
                Email = email.ToLower()
            };
            await _collection.InsertOneAsync(user);
            return user;
        }
    }
}
