using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReviewsController : ControllerBase
  {
    private readonly ReviewsService _revserv;

    public ReviewsController(ReviewsService revserv)
    {
      _revserv = revserv;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get()
    {
      try
      {
        return Ok(_revserv.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Review>> Get(int id)
    {
      try
      {
        return Ok(_revserv.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Review>> Post([FromBody] Review newReview)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newReview.OwnerId = userInfo.Id;
        Review created = _revserv.Create(newReview);
        created.Owner = userInfo;
        return Ok(created);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Review>> Edit(int id, [FromBody] Review editData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editData.Id = id;
        editData.Owner = userInfo;
        editData.OwnerId = userInfo.Id;
        return Ok(_revserv.Edit(editData, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_revserv.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}