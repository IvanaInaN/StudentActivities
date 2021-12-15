using FormActions.Domain.Repositories;
using System.Threading.Tasks;

namespace FormActions.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamRoomContext _context;

        public UnitOfWork(ExamRoomContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
