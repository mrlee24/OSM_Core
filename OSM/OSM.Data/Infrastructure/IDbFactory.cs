using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Data.Infrastructure
{
    public interface IDbFactory
    {
        //Get DbContext
        AppsDbContext GetDataContext { get; }
    }
}
