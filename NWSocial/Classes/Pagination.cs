using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Classes
{
    public class Pagination
    {
        public int? Index { get; set; }
        public int? Items { get; set; }

        public Pagination(int? index,int? items)
        {
            this.Index = index;
            this.Items = items;
        }
    }
}
