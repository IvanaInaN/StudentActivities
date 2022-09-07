using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentActivities.Domain.Repositories;
using StudentActivities.Services.AutoMapper;
using StudentActivities.Services.CQRS.Queries.GetAllStudentActivitiesQuery;
using StudentActivities.UnitTests.Fakes;
using StudentActivities.Web;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StudentActivities.UnitTests
{
    public class Context : IDisposable
    {
        private IHost _host;
        private IServiceScope _serviceScope;

        public Context(FakeStudentActivitiesRepository fakeStudentActivitiesRepository)
        {
            FakeStudentActivitiesRepository = fakeStudentActivitiesRepository;
           
            _host = CreateHost();
            _serviceScope = _host.Services.CreateScope();
            var provider = _serviceScope.ServiceProvider;
            Mediator = provider.GetRequiredService<IMediator>();
        }

        public FakeStudentActivitiesRepository FakeStudentActivitiesRepository { get; }
        
        public IMediator Mediator { get; }
     
        public void Dispose()
        {
            _serviceScope.Dispose();
            _host.Dispose();
        }

        private IHost CreateHost()
        {
            // TODO: check wheather CacheService is a shared dependency
            // TODO: Same sequence for initializing fakes(coaching)

            var hostBuilder = Host.CreateDefaultBuilder()
                   .ConfigureServices((_, services) =>
                   {
                       IConfiguration configuration = new ConfigurationBuilder()
                                .Build();

                       services.AddAutoMapper(typeof(MapperFormAction));

                       services.AddMediatR(typeof(Startup));

                       services.AddMediatR(typeof(GetAllStudentActivitiesQueryHandler).GetTypeInfo().Assembly);

                       services.AddScoped<IStudentActivityRepository, FakeStudentActivitiesRepository>(sp => FakeStudentActivitiesRepository);
                   });

            return hostBuilder.Build();
        }
    }
}
