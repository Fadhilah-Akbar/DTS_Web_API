using DTS_Web_Api.Models;
using DTS_Web_Api.ViewModels;

namespace DTS_Web_Api.Repository.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account, string>
    {
        Task RegisterAsync(RegisterVM registerVM);
        Task<bool> LoginAsync(LoginVM loginVM);
    }
}
