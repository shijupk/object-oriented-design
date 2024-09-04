using JobScheduler.JobScheduler.Abstractions;

namespace JobScheduler.JobScheduler.Features;

public class Job : IJob
{
    private readonly Action _action;

    public Job(TimeSpan interval, Action action, JobPriority priority)
    {
        Interval = interval;
        _action = action;
        Priority = priority;
    }

    public TimeSpan Interval { get; }
    public JobPriority Priority { get; }

    public void Execute()
    {
        _action?.Invoke();
    }

    public bool ShouldExecute(DateTime lastRunTime)
    {
        return DateTime.Now - lastRunTime >= Interval;
    }
}