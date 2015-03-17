using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public class LenseRepository : ILensRepository, IDisposable
    {
        private ItemContext context;

        public LenseRepository(ItemContext context)
        {
            this.context = context;
        }

        public IEnumerable<Lense> GetLenss()
        {
            return context.Lenses.ToList();
        }

        public Lense GetLensByID(int id)
        {
            return context.Lenses.Find(id);
        }

        public void InsertLens(Lense lens)
        {
            context.Lenses.Add(lens);
        }

        public void DeleteLens(int lensID)
        {
            Lense lens = context.Lenses.Find(lensID);
            context.Lenses.Remove(lens);
        }

        public void UpdateLens(Lense lens)
        {
            context.Entry(lens).State = EntityState.Modified;
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