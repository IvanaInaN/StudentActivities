using System.Threading.Tasks;

namespace FormActions.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
