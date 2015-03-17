using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public interface IReviewReository : IDisposable
    {
        IEnumerable<Review> GetReviews();
        Review GetReviewByID(int ReviewId);
        void InsertReview(Review review);
        void DeleteReview(int reviewID);
        void UpdateReview(Review review);
        void Save();
    }
}
