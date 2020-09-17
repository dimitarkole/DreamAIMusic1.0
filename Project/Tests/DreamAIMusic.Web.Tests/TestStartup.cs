using DreamAIMusic.Web.Tests.Mocks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamAIMusic.Web.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            ConfigureServices(services);

            //Mock IHostingEnvironment
            services.AddScoped(_ => HostingEnvironmentMock.CreateInstance());
            services.AddSingleton<IDistributedCache, DistributedCacheMock>();
        }
    }
}
