using BougieCandles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Interfaces
{
    interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}
