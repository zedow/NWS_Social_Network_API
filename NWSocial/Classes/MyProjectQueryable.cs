using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Classes
{
    public static class MyProjectQueryable
    {
        public static IQueryable<Project> IsClosed(this IQueryable<Project> query,bool? isClosed)
        {
            if(isClosed.HasValue)
            {
                return query.Where(p => p.isClosed == isClosed.Value);
            }
            return query;
        }
    }
}
