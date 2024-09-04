namespace JobScheduler.JobScheduler.Abstractions;

public enum JobPriority
{
    Low,
    Medium,
    High
}

public interface IJob
{
    TimeSpan Interval { get; }
    JobPriority Priority { get; }
    void Execute();
    bool ShouldExecute(DateTime lastRunTime);
}