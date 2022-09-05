using StudentActivities.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentActivities.Domain.Repositories
{
    public interface IStudentActivityRepository
    {
        Task<List<StudentActivity>> GetStudentActivitiesAsync();
        void RemoveById(int studentActivityId);
    }
}
