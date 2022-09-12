using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using StudentsActivities.Data;
using StudentActivities.Domain.Repositories;
using StudentActivities.Domain.Models;
using System;

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

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students
                .Where(x => x.Active == 1)
            .ToListAsync();
        }

        public async Task<List<Form>> GetFormsAsync()
        {
            return await _context.Forms
                .Where(x => x.Active == 1)
            .ToListAsync();
        }

        public async Task AddStudent(string name,string city, string street, string email, string phone)
        {
            var student = new Student
            {
                Active = 1,
                City = city,
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Street = street
            };

            var createdStudent = await _context.AddAsync(student);
        }

        public async Task AddForm(string name)
        {
            var form = new Form
            {
                Active = 1,
                Name = name
            };

            var createdStudent = await _context.AddAsync(form);
        }

        public async Task AddStudentActivity(string activity, int formId, int studentId)
        {
            var studentForm = new StudentActivity
            {
                ActionOn = DateTime.Now,
                Action = activity,
                FormId = formId,
                StudentId = studentId
            };

            var createdStudent = await _context.AddAsync(studentForm);
        }
    }
}
