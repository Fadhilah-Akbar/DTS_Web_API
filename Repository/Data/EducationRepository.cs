using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;

namespace DTS_Web_Api.Repository.Data
{
    public class EducationRepository : GeneralRepository<Education, int, MyContext>, IEducationRepository
    {
        public EducationRepository(MyContext context) : base(context)
        {
        }
    }
}
