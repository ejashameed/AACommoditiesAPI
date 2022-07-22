using AA.CommoditiesDashboard.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Interfaces.Repositories
{
    public interface ICommodityRepository
    {
        Task<List<Commodity>> GetAsync();
    }
}
