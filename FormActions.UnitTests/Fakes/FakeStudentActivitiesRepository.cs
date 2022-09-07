using StudentActivities.Domain.Models;
using StudentActivities.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentActivities.UnitTests.Fakes
{
    public class FakeStudentActivitiesRepository : IStudentActivityRepository
    {
        private readonly List<StudentActivity> studentActivities;

        public FakeStudentActivitiesRepository()
        {
            studentActivities = new List<StudentActivity>();
        }

        public void SetUp(List<StudentActivity> activities)
        {
            studentActivities.AddRange(activities);
        }

        public Task<List<StudentActivity>> GetStudentActivitiesByStudentIdAsync(int id)
        {
            var activities = studentActivities.Where(x => x.StudentId == id)
                                .ToList();
            return Task.FromResult(activities);
        }

        public Task<List<StudentActivity>> GetStudentActivitiesAsync()
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int studentActivityId)
        {
            throw new NotImplementedException();
        }
    }
}
