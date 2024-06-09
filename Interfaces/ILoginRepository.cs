using TextPlus_BE.Model;

namespace TextPlus_BE.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> LoginAsync(LoginDto model);

        Task<LoginModel> AddLoginContextAsync(string password, string userId, string email);
    }
}
