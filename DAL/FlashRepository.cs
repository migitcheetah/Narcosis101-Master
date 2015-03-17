using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public class FlashRepository : IFlashRepository, IDisposable
    {
        private ItemContext context;

        public FlashRepository(ItemContext context)
        {
            this.context = context;
        }

        public IEnumerable<Flash> GetFlash()
        {
            return context.Flashes.ToList();
        }
        
        public Flash GetFlashByID(int id)
        {
            return context.Flashes.Find(id);
        }

        public void InsertFlash(Flash camera)
        {
            context.Flashes.Add(camera);
        }

        public void DeleteFlash(int cameraID)
        {
            Flash camera = context.Flashes.Find(cameraID);
            context.Flashes.Remove(camera);
        }

        public void UpdateFlash(Flash camera)
        {
            context.Entry(camera).State = EntityState.Modified;
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