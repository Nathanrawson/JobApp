using JobApp.Interfaces;
using JobApp.Models;

public class JobRepository : IJobRepository
{
    private readonly List<Job> _jobs = new List<Job>();

    public IEnumerable<Job> GetAll()
    {
        return _jobs;
    }

    public Job? GetById(int id)
    {
        return _jobs.FirstOrDefault(j => j.Id == id);
    }

    public void AddOrUpdate(Job job)
    {
        var existingJob = _jobs.FirstOrDefault(j => j.Id == job.Id);
        if (existingJob != null)
        {
            existingJob.Position = job.Position;
            existingJob.Description = job.Description;
            existingJob.DateUpdated = DateTime.Now;
            existingJob.Version += 1;
        }
        else
        {
            job.Id = _jobs.Any() ? _jobs.Last().Id + 1 : 1;
            job.DatePosted = DateTime.Now;
            job.DateUpdated = DateTime.Now;
            job.Version = 1;
            _jobs.Add(job);
        }
    }
}
