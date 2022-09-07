using StudentActivities.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentActivities.UnitTests
{
    public class BaseTest : IDisposable
    {
        protected readonly Context _context;

        public BaseTest()
        {
            _context = new Context(new FakeStudentActivitiesRepository());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
