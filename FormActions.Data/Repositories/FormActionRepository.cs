using FormActions.Domain.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FormActions.Data.Repositories
{
    public class FormActionRepository : IFormActionRepository
    {
        private readonly ExamRoomContext _context;

        public FormActionRepository(ExamRoomContext context)
        {
            _context = context;
        }

        public void RemoveById(int formActionId)
        {
            var a = _context.FormActions.Find(formActionId);
            _context.Remove(a);
            _context.SaveChanges();
        }

        public async Task<List<Domain.Models.FormAction>> GetFormActionsAsync()
        {
            return await _context.FormActions
                 .Include(x => x.Candidate)
                 .Include(x => x.Form)
                 .Where(x => x.Candidate.Active == 1)
                 .Where(x => x.Form.Active == 1)
             .ToListAsync();
        }
    }
}
