using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Data;

namespace NWSocial.Seed
{
    public interface IDbsetSeed
    {
        void Seed(NWSContext context);
    }
}
