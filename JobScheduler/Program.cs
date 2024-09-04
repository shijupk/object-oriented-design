using JobScheduler.JobScheduler.Abstractions;
using JobScheduler.JobScheduler.Features;

namespace JobScheduler;

internal class Program
{
    private static void Main(string[] args)
    {
        var scheduler = SchedulerFactory.Create("Dictionary");
        using var cts = new CancellationTokenSource();
        var task = scheduler.RunAsync(cts.Token);

        var interval1 = TimeSpan.FromSeconds(4); // 30 seconds interval
        IJob job1 = new Job(interval1, () => { Console.WriteLine("High Priority Job1 executed"); }, JobPriority.High);

        var interval2 = TimeSpan.FromSeconds(6); // 1 minute interval
        IJob job2 = new Job(interval2, () => { Console.WriteLine("Medium Priority Job2 executed"); },
            JobPriority.Medium);

        IJob job3 = new Job(TimeSpan.FromSeconds(10), () => { Console.WriteLine("Low Priority Job3 executed"); },
            JobPriority.Low);

        var jobId1 = scheduler.Enqueue(job1);
        var jobId2 = scheduler.Enqueue(job2);
        var jobId3 = scheduler.Enqueue(job3);

        Console.WriteLine("Press any key to cancel the task...");
        //Console.ReadKey();

        while (true)
        {
            Thread.Sleep(1000);
        }

        try
        {
            task.Wait();
        }
        catch (AggregateException ae)
        {
            foreach (var e in ae.InnerExceptions)
            {
                if (e is TaskCanceledException)
                {
                    Console.WriteLine("Task was canceled.");
                }
            }
        }
    }
}