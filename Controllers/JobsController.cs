using System.Collections.Generic;
using Gregslist.Models;
using Gregslist.Service;
using Microsoft.AspNetCore.Mvc;

namespace Gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _cs;
    public JobsController(JobsService cs)
    {
      _cs = cs; 
    }
    [HttpGet]
    public ActionResult<List<Job>> GetJobs()
    {
      try
      {
           var jobs = _cs.Get();
           return Ok(jobs);
      }
      catch (System.Exception error)
      {
         return BadRequest(error.Message);
      }
    }
    [HttpGet("{jobId}")]
    public ActionResult<Job> GetJobById(int jobId)
    {
      try
      {
           var job = _cs.Get(jobId);
           return Ok(job);
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Job> CreateJob([FromBody] Job jobData)
    {
      try
      {
           var job = _cs.CreateJob(jobData);
           return Ok(job);
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
    }
    [HttpPut("{jobId}")]
    public ActionResult<Job> EditJob(int jobId, [FromBody] Job jobData)
    {
      try
      {
           var job = _cs.Edit(jobId, jobData);
           return Ok(job);
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
    }
    [HttpDelete("{jobId}")]
    public ActionResult<Job> DeleteJob(int jobId)
    {
      try
      {
           var job = _cs.Delete(jobId);
           return Ok(job);
      }
      catch (System.Exception error)
      {
         return BadRequest(error.Message);
      }
    }
  }
}