using System.Threading.Tasks;

namespace StudentActivities.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
