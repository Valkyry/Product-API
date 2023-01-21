namespace SampleProject.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(bool isSucceed, string userId)> CreateUserAsync(string userName, string password);
        Task<bool> SigninUserAsync(string userName, string password);
        Task<string> GetUserIdAsync(string userName);
    }
}
