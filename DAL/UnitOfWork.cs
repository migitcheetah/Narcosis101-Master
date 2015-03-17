using System;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ItemContext context = new ItemContext();
        private GenericRepository<Item> itemRepository;
        private GenericRepository<Lense> lenseRepository;

        public GenericRepository<Item> ItemRepository
        {
            get
            {

                if (this.itemRepository == null)
                {
                    this.itemRepository = new GenericRepository<Item>(context);
                }
                return itemRepository;
            }
        }

        public GenericRepository<Lense> LenseRepository
        {
            get
            {

                if (this.lenseRepository == null)
                {
                    this.lenseRepository = new GenericRepository<Lense>(context);
                }
                return lenseRepository;
            }
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