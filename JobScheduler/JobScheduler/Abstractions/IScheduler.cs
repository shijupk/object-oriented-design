namespace JobScheduler.JobScheduler.Abstractions;

public interface IScheduler
{
    Task RunAsync(CancellationToken cancellationToken);
    Guid Enqueue(IJob job);
    void Dequeue(Guid jobId);
}