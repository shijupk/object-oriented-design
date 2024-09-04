using JobScheduler.JobScheduler.Abstractions;

namespace JobScheduler.JobScheduler.SchedulerStrategy;

public class DictionaryJobStorageStrategy : IJobStorageStrategy
{
    private readonly Dictionary<Guid, (IJob Job, DateTime LastRunTime)> _jobs = new();

    public void AddJob(Guid jobId, IJob job)
    {
        _jobs[jobId] = (job, DateTime.MinValue);
    }

    public void RemoveJob(Guid jobId)
    {
        _jobs.Remove(jobId);
    }

    public IEnumerable<(Guid JobId, IJob Job, DateTime LastRunTime)> GetJobs()
    {
        return _jobs.Select(entry => (entry.Key, entry.Value.Job, entry.Value.LastRunTime));
    }

    public void UpdateLastRunTime(Guid jobId, DateTime lastRunTime)
    {
        if (_jobs.ContainsKey(jobId))
        {
            var (job, _) = _jobs[jobId];
            _jobs[jobId] = (job, lastRunTime);
        }
    }
}