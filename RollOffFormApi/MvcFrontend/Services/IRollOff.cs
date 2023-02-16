using MvcFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFrontend.Services.Interfaces
{
    public interface IRollOff
    {
        
        Task<IEnumerable<MyDatum>> Find();
    }
}

