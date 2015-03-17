using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public class CameraRepository : ICameraRepository, IDisposable
    {
        private ItemContext context;

        public CameraRepository(ItemContext context)
        {
            this.context = context;
        }

        public IEnumerable<Camera> GetCameras()
        {
            return context.Cameras.ToList();
        }

        public Camera GetCameraByID(int id)
        {
            return context.Cameras.Find(id);
        }

        public void InsertCamera(Camera camera)
        {
            context.Cameras.Add(camera);
        }

        public void DeleteCamera(int cameraID)
        {
            Camera camera = context.Cameras.Find(cameraID);
            context.Cameras.Remove(camera);
        }

        public void UpdateCamera(Camera camera)
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