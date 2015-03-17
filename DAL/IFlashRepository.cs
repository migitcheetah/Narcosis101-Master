using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public interface IFlashRepository : IDisposable
    {
        IEnumerable<Flash> GetFlash();
        Flash GetFlashByID(int flashID);
        void InsertFlash(Flash flash);
        void DeleteFlash(int flashID);
        void UpdateFlash(Flash flash);
        void Save();
    }
}