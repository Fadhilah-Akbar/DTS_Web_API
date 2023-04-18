using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;

namespace DTS_Web_Api.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        public ProfilingRepository(MyContext context) : base(context)
        {
        }
    }
}
