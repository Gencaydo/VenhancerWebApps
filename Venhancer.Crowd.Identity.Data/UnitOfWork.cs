using Microsoft.EntityFrameworkCore;
using Venhancer.Crowd.Identity.Core.UniteOfWork;

namespace Venhancer.Crowd.Identity.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
