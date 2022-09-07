using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using StudentsActivities.Data;
using StudentActivities.Domain.Repositories;
using StudentActivities.Domain.Models;

namespace StudentsActivities.Data.Repositories
{
    public class FormActionRepository : IStudentActivityRepository
    {
        private readonly StudentActivityContext _context;

        public FormActionRepository(StudentActivityContext context)
        {
            _context = context;
        }

        public void RemoveById(int formActionId)
        {
            var a = _context.StudentActivities.Find(formActionId);
            _context.Remove(a);
            _context.SaveChanges();
        }

        public async Task<List<StudentActivities.Domain.Models.StudentActivity>> GetStudentActivitiesAsync()
        {
            return await _context.StudentActivities
                 .Include(x => x.Student)
                 .Include(x => x.Form)
                 .Where(x => x.Student.Active == 1)
                 .Where(x => x.Form.Active == 1)
             .ToListAsync();
        }

        public async Task<List<StudentActivity>> GetStudentActivitiesByStudentIdAsync(int id)
        {
            return await _context.StudentActivities
                .Include(x => x.Student)
                .Include(x => x.Form)
                .Where(x => x.Student.Active == 1)
                .Where(x => x.Form.Active == 1)
                .Where(x => x.StudentId == id)
            .ToListAsync();
        }
    }
}
