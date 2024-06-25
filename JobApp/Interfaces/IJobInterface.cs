using JobApp.Models;

namespace JobApp.Interfaces
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetAll();
        void AddOrUpdate(Job job);
        Job? GetById(int id);
    }
}
