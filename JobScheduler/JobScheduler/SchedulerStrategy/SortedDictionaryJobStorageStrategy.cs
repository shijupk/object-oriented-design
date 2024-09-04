using JobScheduler.JobScheduler.Abstractions;

namespace JobScheduler.JobScheduler.SchedulerStrategy;

public class SortedDictionaryJobStorageStrategy : IJobStorageStrategy
{
    private readonly SortedDictionary<JobPriority, List<(Guid JobId, IJob Job, DateTime LastRunTime)>> _jobs = new();

    public SortedDictionaryJobStorageStrategy()
    {
        foreach (JobPriority priority in Enum.GetValues(typeof(JobPriority)))
        {
            _jobs[priority] = new List<(Guid, IJob, DateTime)>();
        }
    }

    public void AddJob(Guid jobId, IJob job)
    {
        _jobs[job.Priority].Add((jobId, job, DateTime.MinValue));
    }

    public void RemoveJob(Guid jobId)
    {
        foreach (var priorityGroup in _jobs)
        {
            var jobEntry = priorityGroup.Value.FirstOrDefault(j => j.JobId == jobId);
            if (jobEntry.JobId != default)
            {
                priorityGroup.Value.Remove(jobEntry);
                break;
            }
        }
    }

    public IEnumerable<(Guid JobId, IJob Job, DateTime LastRunTime)> GetJobs()
    {
        return _jobs.SelectMany(priorityGroup => priorityGroup.Value);
    }

    public void UpdateLastRunTime(Guid jobId, DateTime lastRunTime)
    {
        foreach (var priorityGroup in _jobs)
        {
            var jobEntry = priorityGroup.Value.FirstOrDefault(j => j.JobId == jobId);
            if (jobEntry.JobId != default)
            {
                priorityGroup.Value.Remove(jobEntry);
                priorityGroup.Value.Add((jobId, jobEntry.Job, lastRunTime));
                break;
            }
        }
    }
}