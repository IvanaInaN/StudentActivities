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
    public class HostFixture : IDisposable
    {
        private readonly IHost _host;
        private readonly IServiceProvider _provider;

        public HostFixture()
        {
            IHostBuilder CreateHostBuilder() =>
               Host.CreateDefaultBuilder()
                   .ConfigureServices((_, services) =>
                   {
                       IConfiguration configuration = new ConfigurationBuilder()
                                .Build();


                       services.AddAutoMapper(typeof(MapperFormAction));

                       services.AddMediatR(typeof(Startup));

                       services.AddMediatR(typeof(GetAllStudentActivitiesQueryHandler).GetTypeInfo().Assembly);

                       services.AddScoped<IStudentActivityRepository, FakeStudentActivitiesRepository>(sp =>
                       {
                           return new FakeStudentActivitiesRepository();
                       });

                   }
                  );

            _host = CreateHostBuilder().Build();
             var serviceScope = _host.Services.CreateScope();
            _provider = serviceScope.ServiceProvider;
        }

        public IMediator GetMediator()
        {
            return _provider.GetRequiredService<IMediator>();
        }

        public void Dispose()
        {
            _host.Dispose();
        }
    }
}
