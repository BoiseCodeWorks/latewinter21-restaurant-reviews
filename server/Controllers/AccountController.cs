using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize]
  public class AccountController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly ReviewsService _reviewserv;

    public AccountController(ProfilesService ps, ReviewsService reviewserv)
    {
      _ps = ps;
      _reviewserv = reviewserv;
    }

    [HttpGet]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("reviews")]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByAccountId()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_reviewserv.GetReviewsByAccountId(userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}