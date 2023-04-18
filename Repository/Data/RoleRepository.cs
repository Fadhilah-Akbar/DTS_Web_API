using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;

namespace DTS_Web_Api.Repository.Data
{
    public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
    {
        public RoleRepository(MyContext context) : base(context)
        {
        }
    }
}
