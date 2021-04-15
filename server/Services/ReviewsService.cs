using System;
using System.Collections.Generic;
using System.Linq;
using server.Models;
using server.Repositories;

namespace server.Services
{
  public class ReviewsService
  {
    private readonly ReviewsRepository _revsrepo;

    public ReviewsService(ReviewsRepository revsrepo)
    {
      _revsrepo = revsrepo;
    }

    //NOTE is this route necessary?
    internal IEnumerable<Review> GetAll()
    {
      IEnumerable<Review> reviews = _revsrepo.Get();
      return reviews.ToList().FindAll(r => r.Published);
    }

    internal Review Get(int id)
    {
      Review original = _revsrepo.Get(id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      return original;
    }

    internal Review Create(Review newReview)
    {
      newReview.Id = _revsrepo.Create(newReview);
      return newReview;
    }

    internal Review Edit(Review editData, string userId)
    {
      Review original = Get(editData.Id);
      if (original.OwnerId != userId)
      {
        throw new Exception("You cannot edit something you did not create");
      }
      editData.Body = editData.Body == null ? original.Body : editData.Body;
      editData.Title = editData.Title == null ? original.Title : editData.Title;
      return _revsrepo.Edit(editData);
    }


    internal string Delete(int id, string userId)
    {
      Review original = Get(id);
      if (original.OwnerId != userId)
      {
        throw new Exception("You cannot delete something you did not create");
      }
      _revsrepo.Remove(id);
      return "Successsfully Deleted";
    }

    internal IEnumerable<Review> GetByRestaurantId(int id)
    {
      IEnumerable<Review> reviews = _revsrepo.GetByRestaurantId(id);
      return reviews.ToList().FindAll(r => r.Published);
    }


    internal object GetReviewsByProfileId(string id)
    {
      IEnumerable<Review> reviews = _revsrepo.GetByOwnerId(id);
      return reviews.ToList().FindAll(r => r.Published);
    }

    internal IEnumerable<Review> GetReviewsByAccountId(string id)
    {
      return _revsrepo.GetByOwnerId(id);
    }
  }
}