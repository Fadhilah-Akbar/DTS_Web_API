using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DTS_Web_Api.Repository.Data
{
    public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
    {
        public UniversityRepository(MyContext context) : base(context)
        {
        }

        public async Task<bool> IsNameExist(string name)
        {
            var entity = await _context.Set<University>().FirstOrDefaultAsync(x => x.Name == name);
            return entity != null;
        }
    }
}
