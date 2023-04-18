using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;

namespace DTS_Web_Api.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int, MyContext>, IAccountRoleRepository
    {
        public AccountRoleRepository(MyContext context) : base(context)
        {
        }
    }
}
