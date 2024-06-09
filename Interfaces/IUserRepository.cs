using TextPlus_BE.Dto;
using TextPlus_BE.Model;

namespace TextPlus_BE.Interfaces
{
    public interface IUserRepository
    {

        Task<UserModel> RegisterAsync(RegisterModel model);

        Task<UserModel?> GetUserByEmailAsync(string email);
    }
}
