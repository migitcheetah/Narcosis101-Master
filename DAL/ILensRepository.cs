using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Narcosis101.Models;

namespace Narcosis101.DAL
{
    public interface ILensRepository : IDisposable
    {
        IEnumerable<Lense> GetLenss();
        Lense GetLensByID(int lensID);
        void InsertLens(Lense lens);
        void DeleteLens(int lensID);
        void UpdateLens(Lense lens);
        void Save();
    }
}