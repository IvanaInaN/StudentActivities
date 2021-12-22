using FormActions.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormActions.Domain.Repositories
{
    public interface IFormActionRepository
    {
        Task<List<FormAction>> GetFormActionsAsync();
        void RemoveById(int formActionId);
    }
}
