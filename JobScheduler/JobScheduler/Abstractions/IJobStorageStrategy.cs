namespace JobScheduler.JobScheduler.Abstractions;

public interface IJobStorageStrategy
{
    void AddJob(Guid jobId, IJob job);
    void RemoveJob(Guid jobId);
    IEnumerable<(Guid JobId, IJob Job, DateTime LastRunTime)> GetJobs();
    void UpdateLastRunTime(Guid jobId, DateTime lastRunTime);
}