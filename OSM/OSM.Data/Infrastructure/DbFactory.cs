using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Data.Infrastructure
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private  AppsDbContext _context;

        public DbFactory(AppsDbContext context)
        {
            _context = context;
        }

        //Get
        public AppsDbContext GetDataContext
        {
            get
            {
                return _context;
            }
        }

        #region Disposing
        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
            isDisposed = true;
        }
        #endregion
    }
}
