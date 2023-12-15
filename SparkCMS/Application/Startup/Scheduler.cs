using SparkCMS.Application.Jobs;
using Coravel;

namespace SparkCMS.Application.Startup;

public static class Scheduler
{
    public static IServiceProvider RegisterScheduledJobs(this IServiceProvider services)
    {
        services.UseScheduler(scheduler =>
        {
            // example scheduled job
            //scheduler
            //    .Schedule<ExampleJob>()
            //    .EveryFiveMinutes();
        });
        return services;
    }
}