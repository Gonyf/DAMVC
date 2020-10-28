using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.Models;

namespace DAMVC.Interfaces
{
    public interface ICurrentUserResolver
    {
        User Get();
    }
}
