using Venhancer.Crowd.Core.UniteOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venhancer.Crowd.Data
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
