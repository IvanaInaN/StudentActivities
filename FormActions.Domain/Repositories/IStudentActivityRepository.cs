using StudentActivities.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentActivities.Domain.Repositories
{
    public interface IStudentActivityRepository
    {
        Task<List<StudentActivity>> GetStudentActivitiesAsync();
        Task<List<StudentActivity>> GetStudentActivitiesByStudentIdAsync(int id);
        void RemoveById(int studentActivityId);
        Task AddStudent(string name, string city, string street, string email, string phone);
        Task AddStudentActivity(string activity, int formId, int studentId);
        Task AddForm(string name);
        Task<List<Form>> GetFormsAsync();
        Task<List<Student>> GetStudentsAsync();
    }
}
