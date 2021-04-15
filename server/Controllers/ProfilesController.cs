using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using server.Models;
using server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _service;
    private readonly ReviewsService _reviewserv;

    public ProfilesController(ProfilesService service, ReviewsService reviewserv)
    {
      _service = service;
      _reviewserv = reviewserv;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _service.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/reviews")]
    public ActionResult<IEnumerable<Review>> GetReviewsByProfileId(string id)
    {
      try
      {
        return Ok(_reviewserv.GetReviewsByProfileId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}