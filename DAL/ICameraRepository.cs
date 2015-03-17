using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public interface ICameraRepository : IDisposable
    {
        IEnumerable<Camera> GetCameras();
        Camera GetCameraByID(int cameraId);
        void InsertCamera(Camera camera);
        void DeleteCamera(int cameraID);
        void UpdateCamera(Camera camera);
        void Save();
    }
}