using System.Collections.Generic;
using System.Linq;
using Gregslist.Data;
using Gregslist.Models;

namespace Gregslist.Service
{
  public class JobsService
  {
    private readonly FakeDb _db;
    public JobsService(FakeDb db)
    {
      _db = db;
    }
    public Job CreateJob(Job jobData)
    {
      jobData.Id = _db.GenerateId();
      _db.Jobs.Add(jobData);
      return jobData;
    }
    public List<Job> Get()
    {
      return _db.Jobs.Where(c => c.Removed == false).ToList();
    }
    public Job Get(int jobId)
    {
      var job = _db.Jobs.Find(c => c.Id == jobId && c.Removed == false);
      if (job == null)
      {
        throw new System.Exception("Invalid Job Id");
      }
      return job;
    }
    public Job Edit(int jobId, Job jobData)
    {
      var job = Get(jobId);
      job.JobTitle = jobData.JobTitle ?? job.JobTitle;
      job.Company = jobData.Company ?? job.Company;
      job.Description = jobData.Description ?? job.Description;
      job.Rate = jobData.Rate;
      job.Hours = jobData.Hours;
      return job;
    }
    public Job Delete(int jobId)
    {
      var job = Get(jobId);
      job.Removed = true;
      return job;
    }
  }
}