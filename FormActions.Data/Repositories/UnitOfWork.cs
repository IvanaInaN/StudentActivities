using StudentActivities.Domain.Repositories;
using StudentsActivities.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsActivities.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentActivityContext _context;

        public UnitOfWork(StudentActivityContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
