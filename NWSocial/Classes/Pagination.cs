using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Classes
{
    public class Pagination
    {
        public int IndexPage { get; set; }
        public int NumberPerPage { get; set; } = 10;
    }
}
