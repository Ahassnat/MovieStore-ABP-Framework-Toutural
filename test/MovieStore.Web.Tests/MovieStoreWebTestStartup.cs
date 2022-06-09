using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace MovieStore;

public class MovieStoreWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<MovieStoreWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
