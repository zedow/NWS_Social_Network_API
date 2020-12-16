using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Models;

namespace NWSocial.Classes
{
    public static class MyProjectQueryable
    {
        public static IQueryable<Project> IsPrivate(this IQueryable<Project> query,bool? isPrivate)
        {
            if(isPrivate.HasValue)
            {
                return query.Where(p => p.IsPrivate == isPrivate.Value);
            }
            return query;
        }
    }
}
