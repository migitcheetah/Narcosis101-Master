using Narcosis101.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Narcosis101.DAL
{
    public class ReviewRepository : IReviewReository, IDisposable
    {
        private ItemContext context;

        public ReviewRepository(ItemContext context)
        {
            this.context = context;
        }

        public IEnumerable<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        public Review GetReviewByID(int ReviewID)
        {
            return context.Reviews.Find(ReviewID);
        }

        public void InsertReview(Review review)
        {
            context.Reviews.Add(review);
        }

        public void DeleteReview(int ReviewID)
        {
            Review review = context.Reviews.Find(ReviewID);
            context.Reviews.Remove(review);
        }

        public void UpdateReview(Review review)
        {
            context.Entry(review).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }





    }
}
