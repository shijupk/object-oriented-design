using JobScheduler.JobScheduler.Abstractions;

namespace JobScheduler.JobScheduler.Features;

public class Scheduler : IScheduler
{
    private readonly IJobStorageStrategy _jobStorageStrategy;
    private readonly object _lock = new();

    public Scheduler(IJobStorageStrategy jobStorageStrategy)
    {
        _jobStorageStrategy = jobStorageStrategy;
    }

    public Task RunAsync(CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                lock (_lock)
                {
                    foreach (var jobEntry in _jobStorageStrategy.GetJobs())
                    {
                        var (jobId, job, lastRunTime) = jobEntry;
                        if (job.ShouldExecute(lastRunTime))
                        {
                            job.Execute();
                            _jobStorageStrategy.UpdateLastRunTime(jobId, DateTime.Now);
                        }
                    }
                }

                await Task.Delay(1000, cancellationToken); // Adjust delay as necessary
            }
        }, cancellationToken);
    }

    public Guid Enqueue(IJob job)
    {
        lock (_lock)
        {
            var jobId = Guid.NewGuid();
            _jobStorageStrategy.AddJob(jobId, job);
            return jobId;
        }
    }

    public void Dequeue(Guid jobId)
    {
        lock (_lock)
        {
            _jobStorageStrategy.RemoveJob(jobId);
        }
    }
}