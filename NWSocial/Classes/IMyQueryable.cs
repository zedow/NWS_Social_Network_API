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
            if(pagination.Index.HasValue && pagination.Items.HasValue)
            {
                return obj.Skip((pagination.Index.Value - 1) * pagination.Items.Value).Take(pagination.Items.Value);
            }
            return obj;
        }
    }
}
