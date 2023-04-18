using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;

namespace DTS_Web_Api.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context)
        {
        }
    }
}
