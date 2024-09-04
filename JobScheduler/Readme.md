
IScheduler: Defines a scheduler interface that can enqueue and dequeue jobs and run them asynchronously.
IJob: Represents a job interface that includes an Execute method and an interval property.
Scheduler: Implements IScheduler, handling job execution and maintaining thread safety with a lock for concurrency control.
Job: Implements IJob, allowing jobs to be defined with or without an interval.
SchedulerFactory: A factory for creating instances of IScheduler.
This structure ensures that the code follows SOLID principles:

Single Responsibility: Each class has a single responsibility.
Open/Closed Principle: The Scheduler and Job classes are open for extension but closed for modification.
Liskov Substitution: The IScheduler and IJob interfaces ensure that any derived class can be substituted without altering the program's correctness.
Interface Segregation: Interfaces are small and specific, following the ISP.
Dependency Inversion: High-level modules (main) depend on abstractions (IScheduler and IJob), not on concrete implementations.
