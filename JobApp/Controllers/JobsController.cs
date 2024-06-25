using JobApp.Interfaces;
using JobApp.Models;
using Microsoft.AspNetCore.Mvc;

[Route("jobs")]
public class JobsController : Controller
{
    private readonly IJobRepository _jobRepository;

    public JobsController(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    // GET: jobs
    [HttpGet("")]
    public IActionResult Index()
    {
        IEnumerable<Job> jobs = _jobRepository.GetAll();
        return View(jobs);
    }

    // GET: jobs/createorupdate/{id?}
    [HttpGet("createorupdate/{id?}")]
    public IActionResult CreateOrUpdate(int? id)
    {
        if (id == null)
        {
            return View(new Job());
        }
        else
        {
            Job? job = _jobRepository.GetById(id.Value);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }
    }

    // POST: jobs/createorupdate/{id?}
    [HttpPost("createorupdate/{id?}")]
    [ValidateAntiForgeryToken]
    public IActionResult CreateOrUpdate(int? id, [FromForm] Job job)
    {
        if (ModelState.IsValid)
        {
            if (id.HasValue)
            {
                job.Id = id.Value;
            }
            _jobRepository.AddOrUpdate(job);
            return RedirectToAction(nameof(Index));
        }
        return View(job);
    }
}
