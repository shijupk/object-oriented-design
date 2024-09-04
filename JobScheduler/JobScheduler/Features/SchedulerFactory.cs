using JobScheduler.JobScheduler.Abstractions;
using JobScheduler.JobScheduler.SchedulerStrategy;

namespace JobScheduler.JobScheduler.Features;

public static class SchedulerFactory
{
    public static IScheduler Create(string type)
    {
        IJobStorageStrategy strategy = type switch
        {
            "Dictionary" => new DictionaryJobStorageStrategy(),
            "SortedDictionary" => new SortedDictionaryJobStorageStrategy(),
            _ => throw new ArgumentException("Unknown scheduler type")
        };

        return new Scheduler(strategy);
    }
}