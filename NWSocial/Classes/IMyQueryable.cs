using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Classes;

namespace NWSocial.Classes
{
    public static class MyQueryableMethods
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> obj, Pagination pagination)
        {
            if(pagination != null)
            {
                return obj.Skip((pagination.IndexPage - 1) * pagination.NumberPerPage).Take(pagination.NumberPerPage);
            }
            return obj;
        }
    }
}
